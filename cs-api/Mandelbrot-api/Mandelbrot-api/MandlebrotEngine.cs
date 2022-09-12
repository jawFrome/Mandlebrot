using System.Data.Common;

namespace Mandelbrot_api
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// From https://en.wikipedia.org/wiki/Mandelbrot_set
    /// The Mandelbrot set is the set of complex numbers for which the function f_{c}(z)=z^{2}+c} does not diverge to infinity when iterated 
    /// from z=0, i.e., for which the sequence f_{c}(f_{c}(0)) remains bounded in absolute value.
    /// </remarks>
    public class MandlebrotEngine
    {
        public const int UpperIterationLimit = 100;
        public const double UpperSquaredLimit = 4;
                  

        public static bool IsInTheSet(Complex c)
        {
            if (Math.Abs(c.Real) > 2 || Math.Abs(c.Imag) > 2)
            {
                return false;
            }

            return !(Process(c) < UpperIterationLimit);
        }

        private static int Process(Complex c)
        {
            int depth = 0;
            var Zn = new Complex(0, 0);
            do
            {
                Zn = NextZn(Zn, c);
                depth++;
            } while (IsInRange(Zn) && depth < UpperIterationLimit);

            return depth;
        }

        private static Complex NextZn(Complex Zn, Complex C)
        {
            return Zn * Zn + C;
        }

        private static bool IsInRange(Complex value)
        {
            return value.RadiusSquared <= UpperSquaredLimit;
        }
    }
}