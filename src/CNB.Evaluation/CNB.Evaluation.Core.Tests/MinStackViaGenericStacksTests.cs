using CNB.Evaluation.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNB.Evaluation.Core.Tests
{
    public class MinStackViaGenericStacksTests
    {
        [Fact]
        public void ZeroElements_TestPopFails()
        {
            var minStack = new MinStackViaGenericStacks();

            var ex = Assert.Throws<Exception>(() => minStack.pop());

            Assert.Equal("Cannot pop from empty stack!", ex.Message);
        }

        [Fact]
        public void OneElement_TestTopMatches()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;

            minStack.push(value1);

            var top = minStack.top();

            Assert.Equal(value1, top);
        }

        [Fact]
        public void TwoElements_TestTopAndPop()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;
            int value2 = 2;

            minStack.push(value1);
            minStack.push(value2);

            var top = minStack.top();

            Assert.Equal(value2, top);

            minStack.pop();

            top = minStack.top();

            Assert.Equal(value1, top);
        }

        [Fact]
        public void CanPushAndPopMinimumValue()
        {
            var minStack = new MinStackViaGenericStacks();

            minStack.push(int.MinValue);

            var top = minStack.top();

            Assert.Equal(int.MinValue, top);
        }

        [Fact]
        public void CanPushAndPopMaximumValue()
        {
            var minStack = new MinStackViaGenericStacks();

            minStack.push(int.MaxValue);

            var top = minStack.top();

            Assert.Equal(int.MaxValue, top);
        }

        [Fact]
        public void CanPushMaximumSize()
        {
            var minStack = new MinStackViaGenericStacks();
            var minimum = 0;

            var data = MinStackTestData.GenerateTestData(30000, out minimum);

            foreach (var item in data)
            {
                minStack.push(item);
            }

            Assert.Equal(minimum, minStack.getMin());
        }

        [Fact]
        public void CanPush()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;
            int value2 = 2;

            minStack.push(value1);
            minStack.push(value2);
        }

        [Fact]
        public void CanPop()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;

            minStack.push(value1);

            minStack.pop();
        }

        [Fact]
        public void CanTop()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;

            minStack.push(value1);

            var result = minStack.top();

            Assert.Equal(value1, result);
        }

        [Fact]
        public void CanGetMin()
        {
            var minStack = new MinStackViaGenericStacks();

            int value1 = 1;

            minStack.push(value1);

            var result = minStack.getMin();

            Assert.Equal(value1, result);
        }
    }
}
