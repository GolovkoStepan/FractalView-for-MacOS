using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using FractalViewMac.Model.Common.Classes;
using FractalViewMac.Model.Common.Enums;
using FractalViewMac.Model.Fractals;
using SkiaSharp;

namespace FractalViewMac.Model
{
    public class FractalCreator                                     // класс для создания изображений фракталов
    {
        public AbstractFractal FractalData { get; set; }            // данные фрактала
        public GenerationSettings GenerationSettings { get; set; }  // настройки генерации
        public ColorSettings ColorSettings { get; set; }            // настройки цветовой схемы

        int[,] fractalMatrix;                                       // матрица фрактала
        int maxIterations;                                          // максимальное число итераций

        public FractalCreator(AbstractFractal fractalData, GenerationSettings generationSettings, ColorSettings colorSettings)
        {
            FractalData = fractalData;
            GenerationSettings = generationSettings;
            ColorSettings = colorSettings;
            maxIterations = generationSettings.IterationCount;
        }

        // ======================================================================================================================

        // метод создает изображение фрактала согласно всем параметрам
        public SKBitmap Create()
        {
            fractalMatrix = GetFractalMatrix();
            return GetFractalBitmap();
        }

        // метод перерисовывает изображение фрактала на основе уже созданной матрицы
        public SKBitmap ReDraw()
        {
            if (fractalMatrix != null)
            {
                if (maxIterations != GenerationSettings.IterationCount)
                {
                    maxIterations = GenerationSettings.IterationCount;
                    return Create();
                }
                else
                {
                    return GetFractalBitmap();
                }
            }
            else
            {
                return null;
            }
        }

        // асинхронный метод Create()
        public Task<SKBitmap> CreateAsync()
        {
            return Task.Run(() =>
            {
                return Create();
            });
        }

        // асинхронный метод ReDraw()
        public Task<SKBitmap> ReDrawAsync()
        {
            return Task.Run(() =>
            {
                return ReDraw();
            });
        }

        // метод возвращает координату X относительно системы координат фрактала
        public double PositionXFractalCoord(int coordBase)
        {
            return (FractalData.CenterX - FractalData.SizeArea / 2) + (coordBase / GenerationSettings.QualityFactor) * (FractalData.SizeArea / (GenerationSettings.Width / GenerationSettings.QualityFactor));
        }

        // метод возвращает координату Y относительно системы координат фрактала
        public double PositionYFractalCoord(int coordBase)
        {
            return (FractalData.CenterY - FractalData.SizeArea / 2) + ((GenerationSettings.Height - coordBase) / GenerationSettings.QualityFactor) * (FractalData.SizeArea / (GenerationSettings.Height / GenerationSettings.QualityFactor));
        }

        // метод сериализует объект FractalData
        public void SaveFractalInfo(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, FractalData);
            }
        }

        // ======================================================================================================================

        // метод, возвращающий матрицу с учетом типа фрактала и алгоритма расчета
        int[,] GetFractalMatrix()
        {
            switch (GenerationSettings.Algorithm)
            {
                case GenerationAlgorithms.MultiThreadCalculation:
                    {
                        return FractalData.GetFractalMatrixMultiThread(GenerationSettings);
                    }
                case GenerationAlgorithms.OneThreadCalculation:
                    {
                        return FractalData.GetFractalMatrixOneThread(GenerationSettings);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        // метод, возвращающий изображение фрактала
        SKBitmap GetFractalBitmap()
        {
            if (fractalMatrix == null)
            {
                throw new ArgumentNullException(nameof(fractalMatrix));
            }

            switch (ColorSettings.Algorithm)
            {
                case ColorAlgorithms.EscapeTimeAlgorithm:
                    {
                        return EscapeTimeAlgorithm();
                    }
                case ColorAlgorithms.NormalizedIterationCountAlgorithm:
                    {
                        return NormalizedIterationCountAlgorithm();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        #region Методы создания изображения
        // метод, возвращающий изображение фрактала с учетом алгоритма и цветовой схемы (NormalizedIterationCountAlgorithm)
        SKBitmap NormalizedIterationCountAlgorithm()
        {
            if (fractalMatrix == null)
            {
                throw new ArgumentNullException(nameof(fractalMatrix));
            }

            SKBitmap bmp = new SKBitmap(GenerationSettings.Width / GenerationSettings.QualityFactor, GenerationSettings.Height / GenerationSettings.QualityFactor);

            IntPtr pixelsAddr = bmp.GetPixels();

            unsafe
            {
                uint* ptr = (uint*)pixelsAddr.ToPointer();

                for (var i = 0; i < GenerationSettings.Width / GenerationSettings.QualityFactor; i++)
                {
                    for (var j = 0; j < GenerationSettings.Height / GenerationSettings.QualityFactor; j++)
                    {
                        if (fractalMatrix[j, i] > GenerationSettings.IterationCount)
                        {
                            
                            *ptr++ = (uint)ColorSettings.NotFractalPointsColor;

                        }
                        else
                        {
                            double t = fractalMatrix[j, i] / (double)GenerationSettings.IterationCount;

                            byte b = (byte)(9 * (1 - t) * t * t * t * ColorSettings.R);
                            byte g = (byte)(15 * (1 - t) * (1 - t) * t * t * ColorSettings.G);
                            byte r = (byte)(8.5 * (1 - t) * (1 - t) * (1 - t) * t * ColorSettings.B);

                            *ptr++ = (uint)new SKColor(r, g, b);
                        }


                    }
                }
            }

            return bmp;

        }

        // метод, возвращающий изображение фрактала с учетом алгоритма и цветовой схемы (EscapeTimeAlgorithm)
        SKBitmap EscapeTimeAlgorithm()
        {
            if (fractalMatrix == null)
            {
                throw new ArgumentNullException(nameof(fractalMatrix));
            }

            SKBitmap bmp = new SKBitmap(GenerationSettings.Width / GenerationSettings.QualityFactor, GenerationSettings.Height / GenerationSettings.QualityFactor);

            IntPtr pixelsAddr = bmp.GetPixels();

            unsafe
            {
                uint* ptr = (uint*)pixelsAddr.ToPointer();

                for (var i = 0; i < GenerationSettings.Width / GenerationSettings.QualityFactor; i++)
                {
                    for (var j = 0; j < GenerationSettings.Height / GenerationSettings.QualityFactor; j++)
                    {
                        if (fractalMatrix[j, i] > GenerationSettings.IterationCount)
                        {

                            *ptr++ = (uint)ColorSettings.NotFractalPointsColor;

                        }
                        else
                        {
                        
                            byte b = (byte)((fractalMatrix[j, i] * 10) % (ColorSettings.R + 1));
                            byte g = (byte)((fractalMatrix[j, i] * 15) % (ColorSettings.G + 1));
                            byte r = (byte)((fractalMatrix[j, i] * 20) % (ColorSettings.B + 1));

                            *ptr++ = (uint)new SKColor(r, g, b);

                        }

                    }
                }
            }

            return bmp;

        }
        #endregion

    }
}
