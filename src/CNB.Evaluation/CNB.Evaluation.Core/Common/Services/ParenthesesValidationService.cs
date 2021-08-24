using System;
using System.Collections.Generic;
using System.Text;

namespace CNB.Evaluation.Core.Common.Services
{
    public interface IParenthesesValidationService
    {
        bool ValidateStringOfParentheses(string input);
    }

    public class ParenthesesValidationService : IParenthesesValidationService
    {
        public bool ValidateStringOfParentheses(string input)
        {
            Stack<char> s = new Stack<char>();

            var length = input.Length;            

            char top;

            for (int i=0; i<length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    s.Push(input[i]);
                }
                else 
                {
                    if (s.Count == 0) // stack cannot be empty if closing parentheses...
                    {
                        return false;
                    }
                    else
                    {
                        top = s.Peek();

                        if (input[i] == ')' && top == '(' ||
                            input[i] == '}' && top == '{' ||
                            input[i] == ']' && top == '[')
                        {
                            s.Pop();
                        }
                        else // mismatched opening and closing parentheses, therefore input string is invalid...
                        {
                            return false;
                        }
                    }
                }
            }

            if (s.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
