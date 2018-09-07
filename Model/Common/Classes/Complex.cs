namespace FractalViewMac.Model.Common.Classes
{
    struct Complex // структура для работы с комплексными числами
    {
        double re; // реальная часть комплексного числа
        double im; // мнимая часть комплексного числа

        public double MagnitudeSq => re * re + im * im; // квадрат абсолютного значения

        public double Re
        {
            get => re;
            set => re = value;
        }

        public double Im
        {
            get => im;
            set => im = value;
        }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public Complex(Complex c)
        {
            re = c.re;
            im = c.im;
        }

        public static Complex operator +(Complex c1, Complex c2) // операция сложения
        {
            return new Complex()
            {
                re = c1.re + c2.re,
                im = c1.im + c2.im
            };
        }

        public static Complex operator *(Complex c1, Complex c2) // операция умножения
        {
            return new Complex()
            {
                re = c1.re * c2.re - c1.im * c2.im,
                im = c1.re * c2.im + c2.re * c1.im
            };
        }
    }
}
