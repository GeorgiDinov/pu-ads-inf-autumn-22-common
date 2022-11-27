using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDfsAndBfs
{
    internal class Program
    {
        //                     GRAPH
        //                       A
        //                     /   \
        //                   C      B
        //                  /     /   \
        //                 G    D _____ E
        //                            /
        //                           F
        //

        //          ADJACENCY MATRIX REPRESENTATION
        //                  A B C D E F G
        //               A | |1|1| | | | |
        //               B |1| | |1|1| | |
        //               C |1| | | | | |1|
        //               D | |1| | |1| | |
        //               E | |1| |1| |1| |
        //               F | | | | |1| | |
        //               G | | |1| | | | |


        //           ADJACENCY LIST REPRESENTATION
        //                   A {C, B}
        //                   B {A, D, E}
        //                   C {G, A}
        //                   D {B, E}
        //                   E {D, B, F}
        //                   F {E}
        //                   G {C}

        static void Main(string[] args)
        {

            //Create the verices
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");

            //Construct the graph from the above schema
            //ADJACENCY LIST IMPLEMENTATION

            //A {C, B}
            a.AddNeighbour(c);
            a.AddNeighbour(b);

            //B {A, D, E}
            b.AddNeighbour(a);
            b.AddNeighbour(d);
            b.AddNeighbour(e);

            //C {G, A}
            c.AddNeighbour(g);
            c.AddNeighbour(a);

            //D {B, E}
            d.AddNeighbour(b);
            d.AddNeighbour(e);

            //E {D, B, F}
            e.AddNeighbour(d);
            e.AddNeighbour(b);
            e.AddNeighbour(f);

            //F {E}
            f.AddNeighbour(e);

            //G {C}
            g.AddNeighbour(c);


            //The list is to restart the visited state between traversals
            List<Vertex> graph = new List<Vertex>();
            graph.Add(a);
            graph.Add(b);
            graph.Add(c);
            graph.Add(d);
            graph.Add(e);
            graph.Add(f);
            graph.Add(g);


            //Peroform Traversals
            Dfs(a);
            RestartGraphState(graph);

            Bfs(a);
            RestartGraphState(graph);

            Console.Write("Dfs rec. trav.= ");
            DfsRecursive(a);
            Console.WriteLine();
            RestartGraphState(graph);
        }

        private static void Dfs(Vertex startingVertex)
        {
            Console.Write("Dfs traversal = ");
            Stack<Vertex> stack = new Stack<Vertex>();
            startingVertex.IsVisited = true;
            stack.Push(startingVertex);
            while (stack.Count > 0)
            {
                Vertex current = stack.Pop();
                current.IsVisited = true;
                Console.Write(current + " ");
                foreach (Vertex neighbour in current.AdjacencyList)
                {
                    if (!neighbour.IsVisited)
                    {
                        neighbour.IsVisited = true;
                        stack.Push(neighbour);
                    }
                }
            }
            Console.WriteLine();
        }

        //We can use the program call stack to do the DFS
        private static void DfsRecursive(Vertex startingVertex)
        {
            startingVertex.IsVisited = true;
            Console.Write(startingVertex + " ");
            foreach (Vertex neighbour in startingVertex.AdjacencyList)
            {
                if (!neighbour.IsVisited)
                {
                    neighbour.IsVisited = true;
                    DfsRecursive(neighbour);
                }
            }
        }


        private static void Bfs(Vertex startingVertex)
        {
            Console.Write("Bfs traversal = ");
            Queue<Vertex> stack = new Queue<Vertex>();
            startingVertex.IsVisited = true;
            stack.Enqueue(startingVertex);
            while (stack.Count > 0)
            {
                Vertex current = stack.Dequeue();
                current.IsVisited = true;
                Console.Write(current + " ");
                foreach (Vertex neighbour in current.AdjacencyList)
                {
                    if (!neighbour.IsVisited)
                    {
                        neighbour.IsVisited = true;
                        stack.Enqueue(neighbour);
                    }
                }
            }
            Console.WriteLine();
        }



        private static void RestartGraphState(List<Vertex> graph)
        {
            foreach (Vertex vertex in graph)
            {
                vertex.IsVisited = false;
            }
        }


    }
}
