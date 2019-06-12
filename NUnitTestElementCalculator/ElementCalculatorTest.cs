using NUnit.Framework;
using ElementorCalculator;

namespace Tests
{
    public class ElementCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource("ElementCalculator_Test_Cases")]
        public void ElementCalculator_Test(string input, string expectedResult)
        {
            // Arrange
            CalculatorInterface elementCalculator = new ElementCalculator();

            // Act
            elementCalculator.Calculate(input);
            string actualResult = elementCalculator.Print();

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        
        static object[] ElementCalculator_Test_Cases =
        {
           new object[] { "NaCl", "Cl1Na1" },
           new object[] { "Ca(OH)2", "Ca1H2O2" },
           new object[] { "Al2(SO4)3", "Al2O12S3" },
           new object[] { "[Cu(NH3)4(H2O)2]SO4", "Cu1H16N4O6S1" }
        };
    }
}