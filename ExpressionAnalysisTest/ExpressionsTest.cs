using NUnit.Framework;
using ExpressionAnalysis;

namespace ExpressionAnalysisTest
{
    [TestFixture]
    public class ExpressionsTest
    {
        private const string LongExpression = "8+((11+1)*2-(3-2)*2)/2+1";
        private const string ShortExpression = "6*(3+5)-4*7";

        [Test]
        [TestCase(LongExpression)]
        [TestCase(ShortExpression)]
        public void CalculationTest(string str)
        {
            var result = new Expressions().Expression(str);
            Assert.AreEqual(20 , result);
        }
    }
}
