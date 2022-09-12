using System.Data.Common;
using System.Drawing;

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
        public const int UpperIterationLimit = byte.MaxValue;
        public const double UpperSquaredLimit = 4;

        public static Image GetImageOfRange(Complex upperLeft, Complex lowerRight, double resolution)
        {
            var width = (int)Math.Truncate((lowerRight.Real - upperLeft.Real) / resolution);
            var height = (int)Math.Truncate((upperLeft.Imag - lowerRight.Imag) / resolution);
            var image = new Bitmap(width, height);
            int x = 0;
            for (double real = upperLeft.Real; real < lowerRight.Real; real += resolution)
            {
                int y = 0;
                for (double imag = upperLeft.Imag; imag > lowerRight.Imag; imag -= resolution)
                {
                    image.SetPixel(x, y, Color.FromArgb(0, 0, MandlebrotEngine.Process(new Complex(real, imag))));
                    y += 1;
                }
                x += 1;
            }

            return image;
        }
                  

        public static bool IsInTheSet(Complex c)
        {
            if (Math.Abs(c.Real) > 2 || Math.Abs(c.Imag) > 2)
            {
                return false;
            }

            return !(Process(c) < UpperIterationLimit);
        }

        public static byte Process(Complex c)
        {
            byte depth = 0;
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