using System;
using System.Collections.Generic;
using System.Collections;

namespace StackLibrary
{

    public class StackLibrary<T> : IEnumerable<T> // generic type
    {
        private T[] stack;
        private int next;
        public StackLibrary(int capacity = 64)
        {
            stack = new T[capacity];
            next = 0;
        }
        public void ResizeStack(int newCapacity)
        {
            //1. allocate new array
            T[] newStack = new T[newCapacity];
            //2. copy old array to new array
            for (int i = 0; i < next; i++)
            {
                newStack[i] = stack[i];
            }
            //3. set "Stack" to be the new array (update to use the new stack)
            stack = newStack;
        }
        public void Push(T item)
        {
            if (next == stack.Length) //auto resizing
            {
                ResizeStack(2 * stack.Length);
            }
            stack[next] = item;
            next++;
        }
        public T Pop()
        {
            if (
            !IsEmpty()
            ) // or: if (Count/next == 0)
            {
                next--;
                T saved = stack[next];
                stack[next] = default;
                return saved;
            }
            else
            {
                string msg = $"Error: the stack is empty";
                throw new InvalidOperationException(msg);
            }
        }
        public bool IsEmpty()
        {
            if (Count == 0) //or: if (next == 0)
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
                return next; // or next
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = next - 1; i > -1; i--) //array so length -1
            {
                yield return stack[i]; // NB yield: so don't return first one
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
