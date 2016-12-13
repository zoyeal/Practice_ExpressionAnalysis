using NUnit.Framework;
using ExpressionAnalysis;

namespace ExpressionAnalysisTest
{
    [TestFixture]
    public class ExpressionsTest
    {
        private const string LongExpression = "8+((11+1)*2-(3-2)*2)/2+1.5";

        [Test]
        [TestCase(LongExpression)]
        public void CalculationTest(string str)
        {
            var result = new Expressions().Expression(str);
            Assert.AreEqual(20.5 , result);
        }
    }
}
