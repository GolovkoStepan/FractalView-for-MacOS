using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using FractalViewMac.Model.Common.Classes;

namespace FractalViewMac.Model.Fractals
{
    [Serializable]
    public sealed class FractalJulia : AbstractFractal
    {
        public FractalJulia() : base("Julia")
        {
            Reset();
        }

        public FractalJulia(double sizeArea, double centerX, double centerY) : this()
        {
            SizeArea = sizeArea;
            CenterX = centerX;
            CenterY = centerY;
        }

        public override object Clone()
        {
            return new FractalJulia(SizeArea, CenterX, CenterY);
        }

        public override int[,] GetFractalMatrixMultiThread(GenerationSettings generationSettings)
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount - 1
            };

            var fractalMatrix = new int[generationSettings.Width / generationSettings.QualityFactor, generationSettings.Height / generationSettings.QualityFactor];
            Complex c = new Complex(-0.70176, -0.3842);

            Parallel.ForEach(Partitioner.Create(0, ((generationSettings.Width / generationSettings.QualityFactor) * (generationSettings.Height / generationSettings.QualityFactor))), options, range =>
            {
                for (int index = range.Item1; index < range.Item2; index++)
                {
                    int index_i = index / (generationSettings.Width / generationSettings.QualityFactor);
                    int index_j = index % (generationSettings.Height / generationSettings.QualityFactor);


                    Complex z = new Complex(((CenterX - SizeArea / 2) + index_i * (SizeArea / (generationSettings.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + index_j * (SizeArea / (generationSettings.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c;

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
            Complex c = new Complex(-0.70176, -0.3842);

            for (var i = 0; i < generationSettings.Width / generationSettings.QualityFactor; i++)
            {
                for (var j = 0; j < generationSettings.Height / generationSettings.QualityFactor; j++)
                {
                    Complex z = new Complex(((CenterX - SizeArea / 2) + i * (SizeArea / (generationSettings.Width / generationSettings.QualityFactor))),
                                            ((CenterY - SizeArea / 2) + j * (SizeArea / (generationSettings.Height / generationSettings.QualityFactor))));

                    int k;

                    for (k = 1; k <= generationSettings.IterationCount; k++)
                    {
                        z = z * z + c; //formula

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
            SizeArea = 5d;
            CenterX = 0.00476190476190441d;
            CenterY = -0.0166666666666666d;
        }
    }
}
