using System;
using System.Collections.Generic;
using System.Text;

namespace CNB.Evaluation.Core.Common.Models
{
    internal class Element
    {
        internal int Data;

        internal Element Next;

        public Element(int data)
        {
            Data = data;
            Next = null;
        }
    }

    internal class SimpleLinkedList
    {
        internal Element Head;

        internal void Insert(int data)
        {
            var element = new Element(data);
            
            element.Next = this.Head;
            
            this.Head = element;
        }

        internal Element PeekHead()
        {
            return this.Head;
        }

        internal Element ReturnHead()
        {
            var temp = this.Head;

            this.Head = this.Head.Next;

            return temp;
        }
    }

    public class MinStackViaLinkedLists : IMinStack
    {
        // primary internal storage of entire stack of values
        private SimpleLinkedList _primary;

        // auxiliary internal storage of only the current minimum value in the stack of values
        private SimpleLinkedList _auxiliary;

        /// <summary>
        /// initializes the stack object.
        /// </summary>
        public MinStackViaLinkedLists()
        {
            _primary = new SimpleLinkedList();

            _auxiliary = new SimpleLinkedList();
        }

        /// <summary>
        /// pushes the element val onto the stack.
        /// </summary>
        /// <param name="val"></param>
        public void push(int val)
        {
            _primary.Insert(val);

            if (_auxiliary.PeekHead() == null)
            {
                _auxiliary.Insert(val);
            }
            else
            {
                if (_auxiliary.PeekHead().Data >= val)
                {
                    _auxiliary.Insert(val);
                }
            }
        }

        /// <summary>
        /// removes the element on the top of the stack.
        /// </summary>
        public void pop()
        {
            if (_primary.PeekHead() == null)
            {
                throw new Exception("Cannot pop from empty stack!");
            }

            var top = _primary.ReturnHead();

            if (_primary.PeekHead() == null)
            {
                _auxiliary.ReturnHead();
            }
            
            if (_auxiliary.PeekHead() != null)
            {
                if (top != null)
                {
                    if (_auxiliary.PeekHead().Data == top.Data)
                    {
                        _auxiliary.ReturnHead();
                    }
                }
            }
        }

        /// <summary>
        /// gets the top element of the stack.
        /// </summary>
        /// <returns></returns>
        public int top()
        {
            if (_primary.PeekHead() == null)
            {
                throw new Exception("Cannot top from empty stack!");
            }

            var top = _primary.PeekHead();            

            return top.Data;
        }

        /// <summary>
        /// retrieves the minimum element in the stack.
        /// </summary>
        /// <returns></returns>
        public int getMin()
        {
            if (_auxiliary.PeekHead() == null)
            {
                throw new Exception("Cannot get minimum from empty stack!");
            }

            var minimum = _auxiliary.ReturnHead();

            return minimum.Data;
        }
    }
}
