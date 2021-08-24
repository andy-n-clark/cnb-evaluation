using CNB.Evaluation.Core.Common.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CNB.Evaluation.Core.Tests
{
    public class MinStackViaArraysTests
    {
        [Fact]
        public void ZeroElements_TestPopFails()
        {
            var minStack = new MinStackViaArrays();            

            var ex = Assert.Throws<Exception>(() => minStack.pop());

            Assert.Equal("Cannot pop from empty stack!", ex.Message);
        }

        [Fact]
        public void OneElement_TestTopMatches()
        {
            var minStack = new MinStackViaArrays();

            int value1 = 1;

            minStack.push(value1);

            var top = minStack.top();

            Assert.Equal(value1, top);
        }

        [Fact]
        public void TwoElements_TestTopAndPop()
        {
            var minStack = new MinStackViaArrays();

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
            var minStack = new MinStackViaArrays();

            minStack.push(int.MinValue);

            var top = minStack.top();

            Assert.Equal(int.MinValue, top);
        }

        [Fact]
        public void CanPushAndPopMaximumValue()
        {
            var minStack = new MinStackViaArrays();

            minStack.push(int.MaxValue);

            var top = minStack.top();

            Assert.Equal(int.MaxValue, top);
        }

        [Fact]
        public void CanPushMaximumSize()
        {
            var minStack = new MinStackViaArrays();
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
            var minStack = new MinStackViaArrays();

            int value1 = 1;
            int value2 = 2;

            minStack.push(value1);
            minStack.push(value2);
        }

        [Fact]
        public void CanPop()
        {
            var minStack = new MinStackViaArrays();

            int value1 = 1;

            minStack.push(value1);

            minStack.pop();
        }

        [Fact]
        public void CanTop()
        {
            var minStack = new MinStackViaArrays();

            int value1 = 1;

            minStack.push(value1);

            var result = minStack.top();

            Assert.Equal(value1, result);
        }

        [Fact]
        public void CanGetMin()
        {
            var minStack = new MinStackViaArrays();

            int value1 = 1;

            minStack.push(value1);

            var result = minStack.getMin();

            Assert.Equal(value1, result);
        }



        //[Theory]
        //[InlineData(10, -10)]
        //[InlineData(100, -700)]
        //[InlineData(1000, -50000)]
        //public void CanGetMin(int numOfValues, int expected)
        //{
        //    var minStack = new MinStack();

        //    //var data = MinStackTestData.GenerateTestDataWithMinimum(numOfValues, expected);
        //    var data = MinStackTestData.GenerateTestData(numOfValues);

        //    foreach (var d in data)
        //    {
        //        switch (d.Action)
        //        {
        //            case "push":
        //                minStack.push(d.Value);
        //                break;
        //            case "pop":
        //                minStack.pop();
        //                break;
        //            case "top":
        //                var top = minStack.top();
        //                break;
        //            case "minStack":
        //                var min = minStack.getMin();
        //                break;
        //        }
        //    }

        //    var result = minStack.getMin();

        //    Assert.Equal(expected, result);
        //}

        //[Fact]
        //public void AutomatedTestRun()
        //{
        //    var minStack = new MinStack();
        //    var minimum = 0;

        //    var data = MinStackTestData.GenerateTestData(30000, out minimum);

        //    foreach (var d in data)
        //    {
        //        switch (d.Action)
        //        {
        //            case "push":
        //                minStack.push(d.Value);
        //                break;
        //            case "pop":
        //                minStack.pop();
        //                break;
        //            case "top":
        //                var top = minStack.top();
        //                break;
        //            case "minStack":
        //                var min = minStack.getMin();
        //                break;
        //        }
        //    }
        //}
    }
}