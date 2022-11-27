using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BSTree<T> where T : IComparable<T>
    {


        private BSTNode<T> root;

        public BSTree()
        {
            root = null;
        }

        public void Insert(T data)
        {
            if (root == null)
            {
                root = new BSTNode<T>(data);
            }
            root.Insert(data);
        }

        public BSTNode<T> Get(T data)
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Get(data);
        }

        public void Delete(T data)
        {
            root = Delete(root, data);
        }

        private BSTNode<T> Delete(BSTNode<T> subtreeRoot, T data)
        {
            if (subtreeRoot == null)
            {
                return subtreeRoot;
            }

            if (data.CompareTo(subtreeRoot.Data) < 0)
            {
                subtreeRoot.LeftChild = Delete(subtreeRoot.LeftChild, data);
            }
            else if (data.CompareTo(subtreeRoot.Data) > 0)
            {
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, data);
            }
            else
            {
                // we are at the node which we want to delete
                // first we handle cases where we have only one or no children
                // and replace the deleted node with one or the other, or null if there is no children
                if (subtreeRoot.LeftChild == null)
                {
                    return subtreeRoot.RightChild;
                }
                if (subtreeRoot.RightChild == null)
                {
                    return subtreeRoot.LeftChild;
                }

                // if we get to here we know that the node we want to delete has two children
                // we have to pick replacement node for the one we want to delete and preserve the BSTree
                // we either take the minimum node of the right child, or the maximum node of the left child
                // set the value of the picked node for replacement to the one we want to delete, and then delete the replacing node from the tree
                subtreeRoot.Data = subtreeRoot.RightChild.Min();
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, subtreeRoot.Data);
            }
            return subtreeRoot;
        }

        public T Min()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Min();
        }

        public T Max()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            return root.Max();
        }

        public void TraverseInOrder()
        {

            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            Console.Write("In order: ");
            root.TraverseInOrder();
            Console.WriteLine();
        }

        public void TraversePreOrder()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            Console.Write("Pre order: ");
            root.TraversePreOrder();
            Console.WriteLine();
        }

        public void TraversePostOrder()
        {
            if (root == null)
            {
                throw new Exception("Empty tree!");
            }
            Console.Write("Post order: ");
            root.TraversePostOrder();
            Console.WriteLine();
        }


    }
}
