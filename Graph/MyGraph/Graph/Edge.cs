using System;

namespace MyGraph
{
    class Edge
    {
        public int Weight { get; private set; }
        public char To { get; private set; }
        public Edge(int w, char node)
        {
            Weight = w;
            To = node;
        }
    }
}
