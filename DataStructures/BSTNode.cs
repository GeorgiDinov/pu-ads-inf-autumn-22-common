using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    // Binary search tree consists of three nodes called as follows
    //
    //        (parent)
    //         /    \
    //        /      \
    //(leftChild) (rightChild)
    //
    internal class BSTNode<T> where T : IComparable<T>
    {

        private T data;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        private BSTNode<T> leftChild;

        public BSTNode<T> LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        private BSTNode<T> rightChild;

        public BSTNode<T> RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public BSTNode(T data)
        {
            this.data = data;
            this.leftChild = null;
            this.rightChild = null;
        }


        public void Insert(T data)
        {
            if (data.CompareTo(this.data) == 0)
            {
                return; //not to allow duplicates in this implementation
            }

            if (data.CompareTo(this.data) < 0)
            {
                if (leftChild == null)
                {
                    leftChild = new BSTNode<T>(data);
                }
                else
                {
                    leftChild.Insert(data);
                }
            }
            else
            {
                if (rightChild == null)
                {
                    rightChild = new BSTNode<T>(data);
                }
                else
                {
                    rightChild.Insert(data);
                }
            }
        }

        public BSTNode<T> Get(T data)
        {
            if (data.CompareTo(this.data) == 0)
            {
                return this;
            }

            if (data.CompareTo(this.data) < 0)
            {
                if (leftChild != null)
                {
                    return leftChild.Get(data);
                }
            }
            else
            {
                if (rightChild != null)
                {
                    return rightChild.Get(data);
                }
            }
            return null;
        }

        public T Min()
        {
            return leftChild != null ? leftChild.Min() : data;
        }

        public T Max()
        {
            return rightChild != null ? rightChild.Max() : data;
        }


        //traversals with the respect of when we visit the parent node

        public void TraverseInOrder()// visit leftChild, parent and rightChild
        {
            if (leftChild != null)
            {
                leftChild.TraverseInOrder();
            }

            Console.Write(this);

            if (rightChild != null)
            {
                rightChild.TraverseInOrder();
            }
        }

        public void TraversePreOrder()// visit parent, leftChild and rightChild
        {
            Console.Write(this);

            if (leftChild != null)
            {
                leftChild.TraversePreOrder();
            }

            if (rightChild != null)
            {
                rightChild.TraversePreOrder();
            }
        }

        public void TraversePostOrder()// visit leftChild, rightChild and parent
        {
            if (leftChild != null)
            {
                leftChild.TraversePostOrder();
            }

            if (rightChild != null)
            {
                rightChild.TraversePostOrder();
            }

            Console.Write(this);
        }

        public override string ToString()
        {
            return "(" + data + ")";
        }
    }


}
