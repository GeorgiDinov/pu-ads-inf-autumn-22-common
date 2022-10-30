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


            MyQueue<int> queue = new MyQueue<int>(5);

            Console.WriteLine("Add 1");
            queue.Add(1);
            Console.WriteLine("Add 2");
            queue.Add(2);
            Console.WriteLine("Add 3");
            queue.Add(3);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Add 4");
            queue.Add(4);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Remove = " + queue.Remove());
            Console.WriteLine("Remove = " + queue.Remove());
            Console.WriteLine("Add 5");
            queue.Add(5);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Add 6");
            queue.Add(6);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Remove = " + queue.Remove());
            Console.WriteLine("Add 7");
            queue.Add(7);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Add 8");
            queue.Add(8);
            queue.Print();
            queue.PrintQArray();
            Console.WriteLine("Add 9");
            queue.Add(9);
            queue.Print();
            queue.PrintQArray();
        }
    }
}
