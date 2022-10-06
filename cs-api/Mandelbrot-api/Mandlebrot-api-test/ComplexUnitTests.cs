namespace Mandlebrot_api_test
{
    using Mandelbrot_api;

    public class ComplexUnitTests
    {
        static object[] ComplexAddCases =
        {
            new object[] { new Complex(5, 3), new Complex(2, 2), new Complex(7, 5) },
            new object[] { new Complex(-1, 7), new Complex(2, -1), new Complex(1, 6) },
            new object[] { new Complex(0, 0), new Complex(0, 0), new Complex(0, 0) },
        };

        static object[] ComplexMultipyCases =
        {
            new object[] { new Complex(5, 3), new Complex(2, 2), new Complex(4, 16) },
            new object[] { new Complex(-1, 7), new Complex(2, -1), new Complex(5, 15) },
            new object[] { new Complex(0, 0), new Complex(0, 0), new Complex(0, 0) },
        };

        static object[] ComplexEqualsCases =
        {
            new object[] { null, null, true },
            new object[] { new Complex(1, 2), null, false },
            new object[] { new Complex(1, 2), new Complex(2, 1), false },
            new object[] { new Complex(1, 2), new Complex(1, 2), true },
        };

        [TestCaseSource(nameof(ComplexEqualsCases))]
        public void TestEqualsToIsWorking(Complex c1, Complex c2, bool areEqual)
        {
            Assert.That(c1.Equals(c2), Is.EqualTo(areEqual));
        }

        [TestCaseSource(nameof(ComplexAddCases))]
        public void TestAddIsWorking(Complex c1, Complex c2, Complex expectedResult)
        {
            Assert.That(expectedResult , Is.EqualTo(c1 + c2));
        }

        [TestCaseSource(nameof(ComplexMultipyCases))]
        public void TestMultiplyIsWorking(Complex c1, Complex c2, Complex expectedResult)
        {
            Assert.That(expectedResult, Is.EqualTo(c1 * c2));
        }
    }
}