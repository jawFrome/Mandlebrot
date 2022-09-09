using System.Data.Common;

namespace Mandelbrot_api
{
    public class MandlebrotEngine
    {
        public const int UpperIterationLimit = 100;
        public const double UpperSquaredLimit = 4;

        public static int Process(Complex Z0)
        {
            int depth = 0;
            var Zn = Z0;
            do
            {
                Zn = NextZn(Zn, Z0);
                depth++;
            } while (IsInRange(Zn) && depth < UpperIterationLimit);

            return depth;
        }

        public static Complex NextZn(Complex Zn, Complex C)
        {
            return Zn * Zn + C;
        }

        public static bool IsInRange(Complex value)
        {
            return value.RadiusSquared <= UpperSquaredLimit;
        }
    }
}
