namespace CNB.Evaluation.Core.Common.Models
{
    public interface IMinStack
    {        
        /// <summary>
        /// pushes the element val onto the stack.
        /// </summary>
        /// <param name="val"></param>
        public void push(int val);

        /// <summary>
        /// removes the element on the top of the stack.
        /// </summary>
        public void pop();

        /// <summary>
        /// gets the top element of the stack.
        /// </summary>
        /// <returns></returns>
        public int top();

        /// <summary>
        /// retrieves the minimum element in the stack.
        /// </summary>
        /// <returns></returns>
        public int getMin();
    }
}
