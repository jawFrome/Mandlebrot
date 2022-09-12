
namespace Mandelbrot_api
{
    public struct Complex
    {
        public double Real { get; set; }
        public double Imag { get; set; }
              

        public Complex(double real, double imag)
        {
            Real = real;
            Imag = imag;
        }

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

        public override bool Equals(object? x)
        {
            if (x is Complex other)
            {
                if (x == null)
                {
                    return false;
                }

                return other.Real == this.Real && other.Imag == this.Imag;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Real, Imag).GetHashCode();
        }
    }
}