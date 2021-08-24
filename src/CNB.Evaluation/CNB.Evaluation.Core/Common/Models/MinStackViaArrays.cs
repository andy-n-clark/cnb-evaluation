using System;
using System.Collections.Generic;

namespace CNB.Evaluation.Core.Common.Models
{
    /// <summary>
    /// defines a MinStack class using arrays
    /// </summary>
    public class MinStackViaArrays : IMinStack
    {
        // primary internal storage of entire stack of values
        private int[] _primary;
        private int _primaryIndex;        

        // auxiliary internal storage of only the current minimum value in the stack of values
        private int[] _auxiliary;
        private int _auxiliaryIndex;        

        /// <summary>
        /// initializes the stack object.
        /// </summary>
        public MinStackViaArrays()
        {
            _primary = new int[30001];
            _primaryIndex = 0;

            _auxiliary = new int[30001];
            _auxiliaryIndex = 0;            
        }

        /// <summary>
        /// pushes the element val onto the stack.
        /// </summary>
        /// <param name="val"></param>
        public void push(int val)
        {
            _primary[_primaryIndex] = val;
            _primaryIndex++;

            if (_auxiliaryIndex == 0)
            {
                _auxiliary[_auxiliaryIndex] = val;
                _auxiliaryIndex++;
            }
            else
            {
                if (_auxiliary[_auxiliaryIndex - 1] >= val)
                {
                    _auxiliary[_auxiliaryIndex] = val;
                    _auxiliaryIndex++;
                }
            }
        }

        /// <summary>
        /// removes the element on the top of the stack.
        /// </summary>
        public void pop()
        {
            if (_primaryIndex == 0)
            {
                throw new Exception("Cannot pop from empty stack!");
            }

            var top = _primary[_primaryIndex - 1];
            _primaryIndex--;
            
            if (_auxiliary[_auxiliaryIndex - 1] == top)
            {
                _auxiliaryIndex--;
            }
        }

        /// <summary>
        /// gets the top element of the stack.
        /// </summary>
        /// <returns></returns>
        public int top()
        {
            return _primary[_primaryIndex - 1];
        }

        /// <summary>
        /// retrieves the minimum element in the stack.
        /// </summary>
        /// <returns></returns>
        public int getMin()
        {
            if (_auxiliaryIndex == 0)
            {
                throw new Exception("Cannot get minimum from empty stack!");
            }

            return _auxiliary[_auxiliaryIndex - 1];            
        }
    }
}
