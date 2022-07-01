using System;


namespace MyGraph
{
    class Node_dijkstra
    {
        public char Name { get; set; }
        public bool Check { get; set; }
        public char From { get; set; }
        public int Distance { get; set; }
        public Node_dijkstra(char n)
        {
            Name = n;
            Distance = Int32.MaxValue;
        }
    }
    class dijkstra
    {
        Graph graph;
        List<Node_dijkstra> nodes;

        public dijkstra(Graph graph)
        {
            this.graph = graph;
            nodes = new List<Node_dijkstra>();
            FillNodes();
        }

        public string FindWay(char start, char end)
        {
            Node node_start = graph.GetNode(start);
            GetNode(start).Distance = 0;

            while ( node_start.Name != end)
            {
                foreach (Edge _edge in node_start.GetEdges())
                {
                    if (!Check(_edge))
                    {
                        Node_dijkstra node_Dijkstra = GetNode(_edge.To);
                        if (node_Dijkstra.Distance > _edge.Weight +  GetNode(node_start.Name).Distance)
                        {
                            node_Dijkstra.Distance = _edge.Weight;
                            node_Dijkstra.From = node_start.Name;
                        }
                    }
                }
                GetNode(node_start.Name).Check = true;
                node_start = graph.GetNode(nodes.Where(x => !x.Check).MinBy(x => x.Distance).Name);

            }
            string s = new string(GetWay(end).Reverse().ToArray());
            return s;
        }

        private string GetWay(char c)
        {
            Node_dijkstra node = GetNode(c);
            string s = "" + node.Name;
            while (node.From != '\0')
            {
                s += node.From;
                node = GetNode(node.From);
            }
            return s;
        }
        private void FillNodes()
        {
            foreach (Node _node in graph.GetNodes())
            {
                nodes.Add(new Node_dijkstra(_node.Name));
            }
        }

        private Node_dijkstra GetNode(char c)
        {
            foreach (Node_dijkstra _node in nodes)
            {
                if (_node.Name == c)
                {
                    return _node;
                }
            }
            throw new Exception("Такого узла не существует");
        }

        private bool Check(Edge edge)
        {
            return GetNode(edge.To).Check;
        }

    }
}
