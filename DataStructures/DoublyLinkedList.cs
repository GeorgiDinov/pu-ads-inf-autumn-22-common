using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class DoublyLinkedList<T> where T : IComparable<T>
    {

        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        public DoublyLinkedList()
        {
            size = 0;
            head = null;
            tail = null;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void AddFirst(T value)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(value);
                tail = head;
            }
            else
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>(value);
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
            size++;
        }

        public void AddInOrder(T value)
        {
            if (IsEmpty())
            {
                AddFirst(value);
                return;
            }
            int compareResult = value.CompareTo(head.ValueHolder);
            if (compareResult <= 0)
            {
                AddFirst(value);
                return;
            }

            LinkedListNode<T> current = head;
            LinkedListNode<T> next = head.Next;

            while (next != null && next.ValueHolder.CompareTo(value) < 0)
            {
                current = current.Next;
                next = next.Next;
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            current.Next = newNode;
            newNode.Previous = current;

            newNode.Next = next;
            if (next != null)
            {
                next.Previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            size++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            LinkedListNode<T> nodeToRemove = head;
            head = head.Next;
            nodeToRemove.Next = null;
            if (head != null)
            {
                head.Previous = null;
            }
            size--;
            return nodeToRemove.ValueHolder;
        }

        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            return head.ValueHolder;
        }

        public void AddLast(T value)
        {
            if (tail == null)
            {
                tail = new LinkedListNode<T>(value);
                head = tail;
            }
            else
            {
                LinkedListNode<T> newNode = new LinkedListNode<T>(value);
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            size++;
        }

        public void AddLastIterative(T value)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(value);
                tail = head;
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                LinkedListNode<T> newNode = new LinkedListNode<T>(value);
                current.Next = newNode;
                newNode.Previous = current;
                tail = newNode;
            }
            size++;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            LinkedListNode<T> nodeToRemove = tail;
            tail = tail.Previous;
            nodeToRemove.Previous = null;
            if (tail != null)
            {
                tail.Next = null;
            }
            size--;
            return nodeToRemove.ValueHolder;
        }

        public T GetLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }
            return tail.ValueHolder;
        }


        public bool Contains(T value)
        {
            if (IsEmpty())
            {
                throw new Exception("Empty List Exception");
            }

            LinkedListNode<T> first = head;
            LinkedListNode<T> last = tail;

            if (first == last)
            {
                return first.ValueHolder.CompareTo(value) == 0;
            }

            while (first != last)
            {
                if (first.ValueHolder.CompareTo(value) == 0 || last.ValueHolder.CompareTo(value) == 0)
                {
                    return true;
                }
                first = first.Next;
                last = last.Previous;
            }
            return false;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Print()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write(current.ValueHolder + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }


    }//end of class

}
