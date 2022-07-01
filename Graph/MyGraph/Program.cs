using System;

namespace MyGraph
{
    class Program
    {
        static void Vivod(Graph graph)
        {
            Console.WriteLine();
            foreach (Node node in graph.GetNodes())
            {
                Console.Write($"\"{node.Name}\"\t");
                foreach (Edge edge in node.GetEdges())
                {
                    Console.Write(edge.To + " " + edge.Weight + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            Graph graph = new Graph();
            graph.AddNode('A');
            graph.AddNode('B');
            graph.AddNode('C');
            graph.AddNode('D');
            graph.AddNode('E');
            graph.AddNode('F');
            graph.AddNode('G');

            graph.AddEdge('A', 'B', 2);
            graph.AddEdge('A', 'C', 3);
            graph.AddEdge('A', 'D', 6);

            graph.AddEdge('B', 'E', 9);
            graph.AddEdge('B', 'C', 4);

            graph.AddEdge('C', 'E', 7);
            graph.AddEdge('C', 'F', 6);
            graph.AddEdge('C', 'D', 1);

            graph.AddEdge('D', 'F', 4);

            graph.AddEdge('F', 'E', 1);
            graph.AddEdge('F', 'G', 8);

            graph.AddEdge('E', 'G', 5);

            Vivod(graph);

            Console.WriteLine();

            dijkstra dijkstra = new dijkstra(graph);
            Console.WriteLine(dijkstra.FindWay('A','G'));
        }
    }
}
