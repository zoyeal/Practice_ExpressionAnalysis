using System;

namespace ExpressionAnalysis
{
    public class Program
    {
        private static void Main()
        {
            const string expression = "8+((11+1)*2-(3-2)*2)/2";
            var result = new Expressions().Expression(expression);
            Console.WriteLine(expression+" = "+result);
            Console.ReadKey();
        }
    }
}
