using System;


namespace MyGraph
{
    class Node
    {
        public char Name { get; private set; }
        List<Edge> edges;
        public Node(char name)
        {
            Name = name;
            edges = new List<Edge>();
        }
        public void AddEdge(char node,int weight)
        {
            edges.Add(new Edge(weight, node));
        }

        public IEnumerable<Edge> GetEdges()
        {
            foreach (Edge edge in edges)
            {
                yield return edge;
            }
        }
    }
}
