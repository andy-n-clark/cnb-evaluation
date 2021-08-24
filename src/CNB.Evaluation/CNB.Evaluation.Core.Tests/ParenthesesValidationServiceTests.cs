using CNB.Evaluation.Core.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNB.Evaluation.Core.Tests
{
    public class ParenthesesValidationServiceTests
    {
        [Theory]
        [InlineData("()")]
        [InlineData("{}")]
        [InlineData("[]")]
        public void CanValidateSingleValidPair(string data)
        {
            var service = new ParenthesesValidationService();

            var results = service.ValidateStringOfParentheses(data);

            Assert.True(results);
        }

        [Theory]
        [InlineData("()[]{}")]
        [InlineData("(){}[]")]
        [InlineData("{}[]()")]
        [InlineData("{}()[]")]
        [InlineData("[]{}()")]
        [InlineData("[](){}")]
        public void CanValidateAllThreeValidPairs(string data)
        {
            var service = new ParenthesesValidationService();

            var results = service.ValidateStringOfParentheses(data);

            Assert.True(results);
        }

        [Theory]
        [InlineData("(]")]
        [InlineData("(}")]
        [InlineData("{)")]
        [InlineData("{]")]
        [InlineData("[)")]
        [InlineData("[}")]
        public void CanValidateSingleMismatchedPair(string data)
        {
            var service = new ParenthesesValidationService();

            var results = service.ValidateStringOfParentheses(data);

            Assert.False(results);
        }

        [Theory]
        [InlineData("(())")]
        [InlineData("({})")]
        [InlineData("([])")]
        [InlineData("{()}")]
        [InlineData("{{}}")]
        [InlineData("{[]}")]
        [InlineData("[()]")]
        [InlineData("[{}]")]
        [InlineData("[[]]")]
        public void CanValidateSingleNestedPair(string data)
        {
            var service = new ParenthesesValidationService();

            var results = service.ValidateStringOfParentheses(data);

            Assert.True(results);
        }

        [Theory]
        [InlineData("({)}")]
        [InlineData("([)]")]
        [InlineData("{(})")]
        [InlineData("{[}]")]
        [InlineData("[(])")]
        [InlineData("[{]}")]
        public void CanValidateSingleNestedMismatchedPair(string data)
        {
            var service = new ParenthesesValidationService();

            var results = service.ValidateStringOfParentheses(data);

            Assert.False(results);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        [InlineData(5000)]
        public void CanValidateVariousSizes(int size)
        {
            var service = new ParenthesesValidationService();

            var data = ParenthesesValidationServiceTestData.GenerateTestData(size);

            var results = service.ValidateStringOfParentheses(data);

            Assert.True(results);
        }

        [Fact]
        public void CanValidateMaximumSize()
        {
            var service = new ParenthesesValidationService();

            var data = ParenthesesValidationServiceTestData.GenerateTestData(10000);

            var results = service.ValidateStringOfParentheses(data);

            Assert.True(results);
        }

        [Theory]
        [InlineData(100, 1, "(")]
        [InlineData(100, 2, "(")]
        [InlineData(100, 3, "(")]
        [InlineData(100, 1, "{")]
        [InlineData(100, 2, "{")]
        [InlineData(100, 3, "{")]
        [InlineData(100, 1, "[")]
        [InlineData(100, 2, "[")]
        [InlineData(100, 3, "[")]
        [InlineData(100, 1, ")")]
        [InlineData(100, 2, ")")]
        [InlineData(100, 3, ")")]
        [InlineData(100, 1, "}")]
        [InlineData(100, 2, "}")]
        [InlineData(100, 3, "}")]
        [InlineData(100, 1, "]")]
        [InlineData(100, 2, "]")]
        [InlineData(100, 3, "]")]
        [InlineData(1000, 1, "(")]
        [InlineData(1000, 2, "(")]
        [InlineData(1000, 3, "(")]
        [InlineData(1000, 1, "{")]
        [InlineData(1000, 2, "{")]
        [InlineData(1000, 3, "{")]
        [InlineData(1000, 1, "[")]
        [InlineData(1000, 2, "[")]
        [InlineData(1000, 3, "[")]
        [InlineData(1000, 1, ")")]
        [InlineData(1000, 2, ")")]
        [InlineData(1000, 3, ")")]
        [InlineData(1000, 1, "}")]
        [InlineData(1000, 2, "}")]
        [InlineData(1000, 3, "}")]
        [InlineData(1000, 1, "]")]
        [InlineData(1000, 2, "]")]
        [InlineData(1000, 3, "]")]
        [InlineData(10000, 1, "(")]
        [InlineData(10000, 2, "(")]
        [InlineData(10000, 3, "(")]
        [InlineData(10000, 1, "{")]
        [InlineData(10000, 2, "{")]
        [InlineData(10000, 3, "{")]
        [InlineData(10000, 1, "[")]
        [InlineData(10000, 2, "[")]
        [InlineData(10000, 3, "[")]
        [InlineData(10000, 1, ")")]
        [InlineData(10000, 2, ")")]
        [InlineData(10000, 3, ")")]
        [InlineData(10000, 1, "}")]
        [InlineData(10000, 2, "}")]
        [InlineData(10000, 3, "}")]
        [InlineData(10000, 1, "]")]
        [InlineData(10000, 2, "]")]
        [InlineData(10000, 3, "]")]
        public void CanValidateWithInjectedMismatches(int size, int count, string injected)
        {
            var service = new ParenthesesValidationService();

            var data = ParenthesesValidationServiceTestData.GenerateTestData(size);

            var length = injected.Length;

            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                var position = random.Next(data.Length - length);

                data = data.Insert(position, injected);
            }

            var results = service.ValidateStringOfParentheses(data);

            Assert.False(results);
        }

        [Theory]
        [InlineData(100, new string[] { "(", "{", "[" })]
        [InlineData(100, new string[] { ")", "}", "]" })]
        [InlineData(100, new string[] { "({)}", "([)]" })]
        [InlineData(100, new string[] { "{(})", "{[}]" })]
        [InlineData(100, new string[] { "[(])", "[{]}" })]
        [InlineData(1000, new string[] { "(", "{", "[" })]
        [InlineData(1000, new string[] { ")", "}", "]" })]
        [InlineData(1000, new string[] { "({)}", "([)]" })]
        [InlineData(1000, new string[] { "{(})", "{[}]" })]
        [InlineData(1000, new string[] { "[(])", "[{]}" })]
        [InlineData(10000, new string[] { "(", "{", "[" })]
        [InlineData(10000, new string[] { ")", "}", "]" })]
        [InlineData(10000, new string[] { "({)}", "([)]" })]
        [InlineData(10000, new string[] { "{(})", "{[}]" })]
        [InlineData(10000, new string[] { "[(])", "[{]}" })]
        public void CanValidateWithMultipleInjectedMismatches(int size, string[] injected)
        {
            var service = new ParenthesesValidationService();

            var data = ParenthesesValidationServiceTestData.GenerateTestData(size);            

            Random random = new Random();

            foreach (var injectable in injected)
            {
                var length = injectable.Length;
                var position = random.Next(data.Length - length);

                data = data.Insert(position, injectable);
            }

            var results = service.ValidateStringOfParentheses(data);

            Assert.False(results);
        }
    }
}
