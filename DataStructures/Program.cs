using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyStack<int> stack = new MyStack<int>();
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("Pushing  "+i);
            //    stack.Push(i);
            //    stack.Print();
            //}

            //Console.WriteLine();

            //while (stack.Size() != 0)
            //{
            //    Console.WriteLine("Popping  " + stack.Pop());
            //    stack.Print();
            //}


            //MyQueue<int> queue = new MyQueue<int>(5);

            //Console.WriteLine("Add 1");
            //queue.Add(1);
            //Console.WriteLine("Add 2");
            //queue.Add(2);
            //Console.WriteLine("Add 3");
            //queue.Add(3);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Add 4");
            //queue.Add(4);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Remove = " + queue.Remove());
            //Console.WriteLine("Remove = " + queue.Remove());
            //Console.WriteLine("Add 5");
            //queue.Add(5);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Add 6");
            //queue.Add(6);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Remove = " + queue.Remove());
            //Console.WriteLine("Add 7");
            //queue.Add(7);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Add 8");
            //queue.Add(8);
            //queue.Print();
            //queue.PrintQArray();
            //Console.WriteLine("Add 9");
            //queue.Add(9);
            //queue.Print();
            //queue.PrintQArray();

            //DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
            //linkedList.Add(1);
            //linkedList.Add(2);
            //linkedList.Add(3);
            //linkedList.Print();
            //linkedList.AddFirst(7);
            //linkedList.Print();
            //linkedList.AddLast(0);
            //linkedList.Print();
            //Console.WriteLine("Contains 3 = " + linkedList.Contains(3));
            //Console.WriteLine("Contains 5 = " + linkedList.Contains(5));

            //linkedList = new DoublyLinkedList<int>();
            //linkedList.AddInOrder(2);
            //linkedList.Print();
            //linkedList.AddInOrder(7);
            //linkedList.Print();
            //linkedList.AddInOrder(0);
            //linkedList.Print();
            //linkedList.AddInOrder(3);
            //linkedList.Print();
            //linkedList.AddInOrder(1);
            //linkedList.Print();
            //linkedList.AddInOrder(5);
            //linkedList.Print();
            //linkedList.AddInOrder(4);
            //linkedList.Print();
            //linkedList.AddInOrder(6);
            //linkedList.Print();
            //linkedList.AddInOrder(-1);
            //linkedList.Print();

            //Console.WriteLine("Add at the end without the use of the tail reverence");
            //linkedList.AddLastIterative(8);
            //linkedList.Print();
            //Console.WriteLine("Size = " + linkedList.Size);

            //Console.WriteLine("Remove first = "+ linkedList.RemoveFirst());
            //linkedList.Print();
            //Console.WriteLine("Size = " + linkedList.Size);
            //Console.WriteLine("Remove last = " + linkedList.RemoveLast());
            //linkedList.Print();
            //Console.WriteLine("Size = " + linkedList.Size);

            BSTree<int> bsTree = new BSTree<int>();
            bsTree.Insert(25);
            bsTree.Insert(17);
            bsTree.Insert(26);
            bsTree.Insert(14);
            bsTree.Insert(19);
            bsTree.Insert(27);
            bsTree.Insert(31);
            bsTree.Insert(10);
            bsTree.Insert(16);
            bsTree.Insert(20);
            bsTree.Insert(18);
            bsTree.Insert(31);//duplicate
            bsTree.Insert(32);

            //                      25
            //                 17        26
            //            14       19        27
            //          10  16   18  20         31
            //                                     32

            bsTree.TraverseInOrder();
            bsTree.TraversePreOrder();
            bsTree.TraversePostOrder();

            Console.WriteLine("Min = " + bsTree.Min());
            Console.WriteLine("Max = " + bsTree.Max());

            Console.WriteLine("Get 10 = " + bsTree.Get(10));
            Console.WriteLine("Get 31 = " + bsTree.Get(31));
            Console.WriteLine("Get 9999 = " + bsTree.Get(9999));
            Console.WriteLine();
            bsTree.TraverseInOrder();
            Console.WriteLine("Delete 17 ");
            bsTree.Delete(17);
            bsTree.TraverseInOrder();

            Console.WriteLine("Delete 26 ");
            bsTree.Delete(26);
            bsTree.TraverseInOrder();

            Console.WriteLine("Delete 14 ");
            bsTree.Delete(14);
            bsTree.TraverseInOrder();

            Console.WriteLine("Delete 9999 ");
            bsTree.Delete(9999);
            bsTree.TraverseInOrder();

        }
    }
}
