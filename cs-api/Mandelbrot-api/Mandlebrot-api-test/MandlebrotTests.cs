

namespace Mandlebrot_api_test
{
    using Mandelbrot_api;
    using System.Drawing;

    internal class MandlebrotTests
    {
       static object[] IsInTheSetCases =
       {
            new object[] { new Complex(1, 0), false },
            new object[] { new Complex(-1, 0), true },
            new object[] { new Complex(0, 1), true },
            new object[] { new Complex(0, 2), false },
        };

        [TestCaseSource(nameof(IsInTheSetCases))]
        public void IsInTheSet(Complex c, bool isInTheSet)
        {
            Assert.That(MandlebrotEngine.IsInTheSet(c), Is.EqualTo(isInTheSet));
        }
    }
}
