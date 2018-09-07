using System;
using System.Drawing;
using FractalViewMac.Model.Common.Enums;

namespace FractalViewMac.Model.Common.Classes
{
    public class GenerationSettings : ICloneable                // класс, хранящий данные для генерации изображения
    {
        public int Width { get; set; }                          // ширина

        public int Height { get; set; }                         // высота

        public int IterationCount { get; set; }                 // максимальное число итераций

        public int QualityFactor { get; set; }                  // значение качества прорисовки

        public GenerationAlgorithms Algorithm { get; set; }     // алгоритм расчета матрицы фрактала

        public GenerationSettings()
        {
            Width = 500;
            Height = 500;
            IterationCount = 500;
            QualityFactor = 1;
            Algorithm = GenerationAlgorithms.OneThreadCalculation;
        }

        public GenerationSettings(
            int width = 500,
            int height = 500,
            int iterCount = 500,
            GenerationAlgorithms algorithm = GenerationAlgorithms.OneThreadCalculation,
            int qualityFactor = 1)
        {
            Width = width;
            Height = height;
            IterationCount = iterCount;
            QualityFactor = qualityFactor;
            Algorithm = algorithm;
        }

        public object Clone()                                   // реализация интерфейса ICloneable
        {
            return new GenerationSettings(Width, Height, IterationCount, Algorithm, QualityFactor);
        }
    }
}
