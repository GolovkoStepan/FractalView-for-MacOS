using System;
using FractalViewMac.Model.Common.Classes;

namespace FractalViewMac.Model.Fractals
{
    [Serializable]
    public abstract class AbstractFractal : ICloneable
    {
        const double EPSILON = 0.01;

        public double SizeArea { get; set; }                  // коэффициент увеличения  

        public double CenterX { get; set; }                   // координата X центра

        public double CenterY { get; set; }                   // координата Y центра

        public int ZoomFactor { get; set; } = 3;              // фактор увеличения/уменьшения

        public string FractalType { get; }                    // тип фрактала

        protected AbstractFractal(string fractalType)
        {
            FractalType = fractalType;
        }

        public abstract void Reset();                         // сброс параметров до стандартных

        public abstract int[,] GetFractalMatrixOneThread(GenerationSettings generationSettings);   // создание матрицы фрактала (однопоточные расчеты)
        public abstract int[,] GetFractalMatrixOneThread();

        public abstract int[,] GetFractalMatrixMultiThread(GenerationSettings generationSettings); // создание матрицы фрактала (многопоточные расчеты)
        public abstract int[,] GetFractalMatrixMultiThread();

        public abstract object Clone();                       // реализация интерфейса ICloneable

        public void ZoomPlus()                                // увеличение изображения
        {
            SizeArea /= ZoomFactor;
        }

        public void ZoomMinus()                               // уменьшение изображения
        {
            SizeArea *= ZoomFactor;
        }

        public override string ToString()                     // переопределение метода ToString()
        {
            return $"Type: {FractalType}; X: {CenterX}; Y: {CenterY}; Zoom: {SizeArea};";
        }

        public override int GetHashCode()                     // переопределение метода GetHashCode()
        {
            var hash = 19;

            hash *= 37 + CenterX.GetHashCode();
            hash *= 37 + CenterY.GetHashCode();
            hash *= 37 + SizeArea.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)               // переопределение метода Equals()
        {
            if (!(obj is AbstractFractal))
            {
                return false;
            }

            var data = obj as AbstractFractal;

            if (FractalType == data.FractalType)
            {
                if (Math.Abs(CenterX - data.CenterX) < EPSILON)
                {
                    if (Math.Abs(CenterY - data.CenterY) < EPSILON)
                    {
                        if (Math.Abs(SizeArea - data.SizeArea) < EPSILON)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
