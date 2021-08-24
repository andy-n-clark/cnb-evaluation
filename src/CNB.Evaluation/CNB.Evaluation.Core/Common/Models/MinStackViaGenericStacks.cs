using System;
using System.Collections.Generic;

namespace CNB.Evaluation.Core.Common.Models
{
    public class MinStackViaGenericStacks : IMinStack
    {
        // primary internal storage of entire stack of values
        private Stack<int> _primary;

        // auxiliary internal storage of only the current minimum value in the stack of values
        private Stack<int> _auxiliary;

        /// <summary>
        /// initializes the stack object.
        /// </summary>
        public MinStackViaGenericStacks()
        {
            _primary = new Stack<int>(30001);
            _auxiliary = new Stack<int>(30001);
        }

        /// <summary>
        /// pushes the element val onto the stack.
        /// </summary>
        /// <param name="val"></param>
        public void push(int val)
        {
            _primary.Push(val);

            if (_auxiliary.Count == 0)
            {
                _auxiliary.Push(val);
            }
            else
            {
                if (_auxiliary.Peek() >= val)
                {
                    _auxiliary.Push(val);
                }
            }
        }

        /// <summary>
        /// removes the element on the top of the stack.
        /// </summary>
        public void pop()
        {
            if (_primary.Count == 0)
            {
                throw new Exception("Cannot pop from empty stack!");
            }

            var top = _primary.Pop();

            if (_auxiliary.Peek() == top)
            {
                _auxiliary.Pop();
            }
        }

        /// <summary>
        /// gets the top element of the stack.
        /// </summary>
        /// <returns></returns>
        public int top()
        {
            return _primary.Peek();
        }

        /// <summary>
        /// retrieves the minimum element in the stack.
        /// </summary>
        /// <returns></returns>
        public int getMin()
        {
            if (_auxiliary.Count == 0)
            {
                throw new Exception("Cannot get minimum from empty stack!");
            }

            return _auxiliary.Peek();
        }
    }
}
