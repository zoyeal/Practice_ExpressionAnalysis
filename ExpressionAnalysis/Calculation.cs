using System.Collections;

namespace ExpressionAnalysis
{
    public class Calculation
    {

        public float MultiCalculations(ArrayList arrayList)
        {
            while (arrayList.Count > 3)
            {
                if (arrayList.Contains('*'))
                {
                    arrayList = ReplaceExpression(arrayList, '*');
                }
                else if (arrayList.Contains('/'))
                {
                    arrayList = ReplaceExpression(arrayList, '/');
                }
                else if (arrayList.Contains('+'))
                {
                    arrayList = ReplaceExpression(arrayList, '+');
                }
                else if (arrayList.Contains('-'))
                {
                    arrayList = ReplaceExpression(arrayList, '-');
                }
            }
            return Calculate(arrayList);
        }

        public ArrayList ReplaceExpression(ArrayList arrayList, char p)
        {
            var index = arrayList.IndexOf(p);
            var result = Calculate(arrayList.GetRange(index - 1, 3));
            arrayList.RemoveRange(index - 1, 3);
            arrayList.Insert(index - 1, result);
            return arrayList;
        }

        public float Calculate(ArrayList expressionArray)
        {
            var numLeft = float.Parse(expressionArray[0].ToString());
            var numRight = float.Parse(expressionArray[2].ToString());
            var Operator = expressionArray[1].ToString();

            switch (Operator)
            {
                case "+":
                    return numLeft + numRight;
                case "-":
                    return numLeft - numRight;
                case "*":
                    return numLeft * numRight;
                case "/":
                    return numLeft / numRight;
            }

            return 0;
        }
    }
}
