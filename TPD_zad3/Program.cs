using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> network = new Graph<int>();

            //create 5 nodes
            for (int i = 0; i < 5; i++)
            {
                network.AddNode(i + 1);
            }

            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(2), 4);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(3), 3);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(5), 10);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(4), 8);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(3), 1);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(4), 2);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(5), 6);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(3), network.NodeSet.FindByValue(5), 3);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(3), network.NodeSet.FindByValue(4), 2);
            network.AddUndirectedEdge(network.NodeSet.FindByValue(4), network.NodeSet.FindByValue(5), 1);

            Console.ReadLine();
        }
    }
}
