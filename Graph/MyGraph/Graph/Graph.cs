using System;

namespace MyGraph
{
    class Graph
    {
        private List<Node> nodes;
        public Graph()
        {
            nodes = new List<Node>();
        }

        public void AddNode(char name)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == name)
                    throw new Exception("Такой узел уже есть");
            }
            nodes.Add(new Node(name));
            Console.WriteLine($"Узел \"{name}\" успешно добавлен");
        }

        public void AddEdge(char node1, char node2, int weight)
        {
            GetNode(node1).AddEdge(node2, weight);
            GetNode(node2).AddEdge(node1, weight);
        }

        public Node GetNode(char n)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == n)
                    return node;
            }
            throw new Exception($"Узла \"{n}\" не существует");
        }

        public IEnumerable<Node> GetNodes()
        {
            foreach (Node node in nodes)
            {
                yield return node;
            }
        }
    }
}
