using System;

namespace MyStack
{
    public class MyStack
    {
        private string[] stack;
        private counter = 0;
        public MyStack(int capacity = 64)
        {
            stack = new string[capacity];
            counter = 0;
        }

        public void Push(string item)
        {
            if(counter < stack.Length)
            {
                stack[counter] = item;
                counter++;
            }
            else
            {
                string msg = $"Error: the stack is full(capacity = {stack.Length}";
                throw new Exception(msg);
            }
        }

        public string Pop()
        {
            if(counter > 0)
            {
                return stack[--counter]; //returns before
            }
            else
            {
                string msg = $"Error: the  stack is empty";
                throw new InvalidOperationException(msg);
            }
        }

        public bool IsEmpty()
        {
            if(counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                return counter;
            }
        }
    }
}
