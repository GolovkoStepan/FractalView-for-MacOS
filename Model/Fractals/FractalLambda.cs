using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using FractalViewMac.Model.Common.Classes;

namespace FractalViewMac.Model.Fractals
{
    [Serializable]
    public sealed class FractalLambda : AbstractFractal
    {
        public FractalLambda() : base("Lambda")
        {
            Reset();
        }

        public FractalLambda(double sizeArea, double centerX, double centerY) : this()
        {
            SizeArea = sizeArea;
            CenterX = centerX;
            CenterY = centerY;
        }

        public override object Clone()
        {
            return new FractalLambda(SizeArea, CenterX, CenterY) as object;
        }

        public override int[,] GetFractalMatrixMultiThread(GenerationSettings generationSettings)
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };

            var fractalMatrix = new int[generationSettings.Width / generationSettings.QualityFactor, generationSettings.Height / generationSettings.QualityFactor];

            Parallel.ForEach(Partitioner.Create(0, ((generationSettings.Width / generationSettings.QualityFactor) * (generationSettings.Height / generationSettings.QualityFactor))), options, range =>
            {
                for (int index = range.Item1; index < range.Item2; index++)
                {
                    int index_i = index / (generationSettings.Width / generationSettings.QualityFactor);
                    int index_j = index % (generationSettings.Height / generationSettings.QualityFactor);

                    int k;

                    Complex z = new Complex(0.5, 0);
                    Complex c = new Complex(((CenterX - SizeArea / 2) + index_i * (SizeArea / (generationSettings.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + index_j * (SizeArea / (generationSettings.Height / generationSettings.QualityFactor))));

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        Complex lambda = new Complex(z.Re - Math.Pow(z.Re, 2) + Math.Pow(z.Im, 2), z.Im - 2 * z.Re * z.Im);

                        z = c * lambda;

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[index_i, index_j] = k;
                }
            });

            return fractalMatrix;
        }

        public override int[,] GetFractalMatrixMultiThread()
        {
            return GetFractalMatrixMultiThread(new GenerationSettings());
        }

        public override int[,] GetFractalMatrixOneThread(GenerationSettings generationSettings)
        {
            var fractalMatrix = new int[generationSettings.Width, generationSettings.Height];

            for (var i = 0; i < generationSettings.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex(0.5, 0);
                    Complex c = new Complex(((CenterX - SizeArea / 2) + i * (SizeArea / (generationSettings.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + j * (SizeArea / (generationSettings.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        Complex lambda = new Complex(z.Re - Math.Pow(z.Re, 2) + Math.Pow(z.Im, 2), z.Im - 2 * z.Re * z.Im);

                        z = c * lambda;

                        if (z.MagnitudeSq > 4)
                        {
                            break;
                        }
                    }

                    fractalMatrix[i, j] = k;
                }
            }

            return fractalMatrix;
        }

        public override int[,] GetFractalMatrixOneThread()
        {
            return GetFractalMatrixOneThread(new GenerationSettings());
        }

        public override void Reset()
        {
            CenterX = 1.05142857142857d;
            CenterY = -0.0642857142857185d;
            SizeArea = 7d;
        }
    }
}
