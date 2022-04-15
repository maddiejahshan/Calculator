using System;
using System.Collections;
using System.Collections.Generic;

namespace _2022_Spring_MaddieJahshan_MyQueueLibrary
{
    // 1. Create Node
    // 2. Link in Node
    // 3. Count++
    // 4. Update Tail


    // 1. Start at head
    // 2. Move on to next
    // 3. Until read end
    public class MyQueue<T> : IEnumerable<T>
    {
        internal class Node<T>
        {
            public T data;
            public Node<T> next;

            public Node()
            {
                data = default;
                next = null;
            }

            public Node(T initialValue)
            {
                data = initialValue;
                next = null;
            }
        } //end of node class

        private Node<T> head;
        private Node<T> tail;
        private int count;



        public MyQueue()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            Node<T> n = new Node<T>(item);
            if (count == 0)
            {
                //This is first item in queue
                head = n;
                tail = n;

            }
            else
            {
                tail.next = n;
                tail = n;
            }
            count++;
        }


        bool IsEmpty()
        {
            if (count == 0)
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
                return count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> curr = head;
            while (curr != null)
            {
                yield return curr.data; //yield picks up where it left off
                curr = curr.next;
            }

            //updates current item to next item in the queue
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Dequeue()
        {
            if(count == 0)
            {
                throw new InvalidOperationException("The queue ");
            }

            count--;
            QueueNode<T> node = head;
            head = head.next;

            node.next = null;
            if(count == 0)
            {
                tail = null;
            }
            return node.data;
        }
        public override string ToString()
        {
            /*count 
            every item
            type
            name */
            string description = $"MyQueue({count})";

            if(count > 0)
            {
                QueueNode<T> node = head;
                description += $":{{{node.data}";
                node = node.next;

                for(int i = 1; i < Math.Min(5, count); i++)
                {
                    description += $", {node.data}";
                    node = node.next;
                }

                if(count > 5)
                {
                    description += ", .....";
                }
                description += "}";

            }
            return description; 
            
        }
    }
}
