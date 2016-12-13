using System.Collections;
using System.Linq;
using System.Text;

namespace ExpressionAnalysis
{
    public class Expressions : Calculation
    {
        public static readonly string Operators = "+-*/()";

        public float Expression(string expressionString)
        {
            var expressionArray = StringToArray(expressionString.Trim());

            while (expressionArray.Contains('('))
            {
                expressionArray = GetInnerExpression(expressionArray);
            }

            var result = MultiCalculations(expressionArray);
            return result;
        }

        private ArrayList GetInnerExpression(ArrayList expressionArray)
        {
            var rightIndex = expressionArray.IndexOf(')');
            var leftIndex = 0;

            // Find the nearest right bracket and coressponding left bracket
            for (var i = 0; i < rightIndex; i++)
            {
                if (IsLeftBracket(expressionArray[i].ToString()))
                    leftIndex = i;
            }

            // Calculate the expression between two brackets
            var shortExpression =
                expressionArray.GetRange(leftIndex + 1, rightIndex - leftIndex - 1);

            var result = shortExpression.Count > 3 ?
                MultiCalculations(shortExpression) : Calculate(shortExpression);

            // Replace the inner expression to the result
            expressionArray.RemoveRange(leftIndex,
                expressionArray.IndexOf(')') - leftIndex + 1);
            expressionArray.Insert(leftIndex, result);

            return expressionArray;
        }

        private static bool IsLeftBracket(string str)
        {
            return str == "(";
        }

        public ArrayList StringToArray(string expressionString)
        {
            var expression = new ArrayList();
            var expressionQueue = new Queue();

            for (var i = 0; i < expressionString.Length; i++)
            {
                if (Operators.Contains(expressionString[i]))
                {
                    if (expressionQueue.Count > 0)
                        expression.Add(QueueToString(expressionQueue));
                    expression.Add(expressionString[i]);
                }
                else
                    expressionQueue.Enqueue(expressionString[i]);

                if (i == expressionString.Length - 1)
                    expression.Add(QueueToString(expressionQueue));
            }
            return expression;
        }

        private static string QueueToString(Queue strQueue)
        {
            var strbd = new StringBuilder();
            while (strQueue.Count > 0)
            {
                strbd.Append(strQueue.Dequeue());
            }
            return strbd.ToString();
        }
    }
}
