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
        const int Width = 800;
        const int Height = 800;

        public static Image GetImageOfRange(Complex upperLeft, Complex lowerRight)
        {
            var xResolution = (lowerRight.Real - upperLeft.Real) / Width;
            var yResolution = (upperLeft.Imag - lowerRight.Imag) / Height;
            var image = new Bitmap(Width, Height);
            int x = 0;
            for (double real = upperLeft.Real; real < lowerRight.Real; real += xResolution)
            {
                int y = 0;
                for (double imag = upperLeft.Imag; imag > lowerRight.Imag; imag -= yResolution)
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