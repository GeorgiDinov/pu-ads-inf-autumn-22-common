using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class MyQueue<T>
    {
        private const int DefaultQCapacity = 10;

        private int front;
        private int back;
        private T[] q;

        public MyQueue() : this(DefaultQCapacity)
        {
        }

        public MyQueue(int capacity)
        {
            this.front = 0;
            this.back = 0;
            this.q = new T[capacity];
        }

        public void Add(T item)
        {
            if (Size() == q.Length - 1)
            {
                int numberOfItems = Size();
                T[] replacementQ = new T[q.Length * 2];
                if (IsNotWrapped())
                {
                    Array.Copy(q, front, replacementQ, 0, back);
                }
                else
                {
                    Array.Copy(q, front, replacementQ, 0, q.Length - front);
                    Array.Copy(q, 0, replacementQ, q.Length - front, back);
                }
                q = replacementQ;
                front = 0;
                back = numberOfItems;
            }
            q[back] = item;
            if (back < q.Length - 1)
            {
                back++;
            }
            else
            {
                back = 0;
            }
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Q exception.");
            }
            T itemToRemove = q[front];
            q[front] = default;
            front++;
            if (IsEmpty())
            {
                front = 0;
                back = 0;
            }
            if (front == q.Length)
            {
                front = 0;
            }
            return itemToRemove;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Q exception.");
            }
            return q[front];
        }

        public int Size()
        {
            if (IsNotWrapped())
            {
                return back - front;
            }
            return (back - front) + q.Length;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        //*** Note "Single responsibility" violation(S.O.L.I.D.)
        public void Print()
        {
            Console.Write("Queue = ");
            if (IsNotWrapped())
            {
                for (int i = front; i < back; i++)
                {
                    Console.Write(q[i] + " ");
                }
            }
            else
            {
                for (int i = front; i < q.Length; i++)
                {
                    Console.Write(q[i] + " ");
                }
                for (int i = 0; i < back; i++)
                {
                    Console.Write(q[i] + " ");
                }
            }
            Console.WriteLine();
        }

        //*** Note "Single responsibility" violation(S.O.L.I.D.)
        // This one is for testing and better understanding of the wrapping process
        public void PrintQArray()
        {
            Console.Write("Queue Actual = ");
            for (int i = 0; i < q.Length; i++)
            {
                Console.Write(q[i] + " ");
            }
            Console.WriteLine();
        }

        private bool IsNotWrapped()
        {
            return front <= back;
        }
    }
}
