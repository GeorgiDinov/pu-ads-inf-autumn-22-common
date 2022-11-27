using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class LinkedListNode<T> where T : IComparable<T>
    {
        private T valueHolder;

        public T ValueHolder
        {
            get { return valueHolder; }
            set { valueHolder = value; }
        }

        private LinkedListNode<T> previous;

        public LinkedListNode<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        private LinkedListNode<T> next;

        public LinkedListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public LinkedListNode(T value)
        {
            valueHolder = value;
            previous = null;
            next = null;
        }
    }
}
