namespace Mandelbrot_api
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imag { get; set; }

        public double RadiusSquared
        {
            get { return Real * Real + Imag * Imag; }
        }

        public double Radius
        {
            get { return Math.Sqrt(RadiusSquared); }
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            var multipliedValue = new Complex()
            {
                Real = c1.Real*c2.Real - c2.Imag*c1.Imag,
                Imag = c1.Real*c2.Imag + c1.Imag*c2.Real,                    
            };

            return multipliedValue;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            var multipliedValue = new Complex()
            {
                Real = c1.Real + c2.Real,
                Imag = c1.Imag + c2.Imag,
            };

            return multipliedValue;
        }
    }
}
