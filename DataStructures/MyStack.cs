using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class MyStack<T>
    {
        private const int DefaultStackSize = 10;

        private int top;
        private T[] stack;


        public MyStack() : this(DefaultStackSize)
        {
        }

        public MyStack(int capacity)
        {
            this.top = 0;
            this.stack = new T[capacity];
        }


        public void Push(T item)
        {
            if (top == stack.Length)
            {
                T[] replacementStack = new T[stack.Length * 2];
                Array.Copy(stack, 0, replacementStack, 0, top);
                stack = replacementStack;
            }
            stack[top++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception.");
            }

            T poppedItem = stack[top - 1];
            stack[top - 1] = default; //Optional, null out the value at this position
            top--;
            return poppedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception.");
            }
            return stack[top - 1];
        }

        public int Size()
        {
            return top;
        }


        public bool IsEmpty()
        {
            return top == 0;
        }

        //*** Note "Single responsibility" violation(S.O.L.I.D.)
        public void Print()
        {
            T[] copyToPrint = GetReversedCopyOfTheStack();
            for (int i = 0; i < copyToPrint.Length; i++)
            {
                Console.WriteLine("\t[" + copyToPrint[i] + "]");
            }
            Console.WriteLine();
        }

        private T[] GetReversedCopyOfTheStack()
        {
            T[] stackCopy = new T[top];
            for (int i = top - 1, j = 0; i >= 0; i--, j++)
            {
                stackCopy[j] = stack[i];
            }
            return stackCopy;
        }

    }
}
