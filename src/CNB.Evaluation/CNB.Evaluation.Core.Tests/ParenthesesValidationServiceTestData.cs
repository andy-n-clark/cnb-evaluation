using System;
using System.Collections.Generic;
using System.Text;

namespace CNB.Evaluation.Core.Tests
{
    public class ParenthesesValidationServiceTestData
    {
        public static char RandomParentheses
        {
            get
            {
                Random random = new Random();
                var pick = random.Next(3);

                switch (pick)
                {
                    case 0:
                        return '(';
                    case 1:
                        return '{';
                    case 2:
                        return '[';
                    default:
                        return '(';
                }
            }
        }        

        public static string GenerateTestData(int size)
        {
            var output = string.Empty;

            for (int i = 0; i < size; i++)
            {
                var random = RandomParentheses;

                switch (random)
                {
                    case '(':
                        output = "(" + output + ")";
                        break;
                    case '{':
                        output = "{" + output + "}";
                        break;
                    case '[':
                        output = "[" + output + "]";
                        break;
                    default:
                        output = "(" + output + ")";
                        break;
                }
            }

            return output;
        }
    }
}
