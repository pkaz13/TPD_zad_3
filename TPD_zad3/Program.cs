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

            //create edges between nodes
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(2));
            network.NodeSet.FindByValue(1).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 2, cost = 4 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(3));
            network.NodeSet.FindByValue(1).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 3, cost = 3 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(4));
            network.NodeSet.FindByValue(1).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 4, cost = 8 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(1), network.NodeSet.FindByValue(5));
            network.NodeSet.FindByValue(1).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 5, cost = 10 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(3));
            network.NodeSet.FindByValue(2).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 3, cost = 1 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(4));
            network.NodeSet.FindByValue(2).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 4, cost = 2 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(2), network.NodeSet.FindByValue(5));
            network.NodeSet.FindByValue(2).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 5, cost = 6 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(3), network.NodeSet.FindByValue(5));
            network.NodeSet.FindByValue(3).EdgeInfos.Add(new EdgeInfo<int> { from = 3, to = 5, cost = 3 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(3), network.NodeSet.FindByValue(4));
            network.NodeSet.FindByValue(3).EdgeInfos.Add(new EdgeInfo<int> { from = 3, to = 4, cost = 2 });
            network.AddUndirectedEdge(network.NodeSet.FindByValue(4), network.NodeSet.FindByValue(5));
            network.NodeSet.FindByValue(4).EdgeInfos.Add(new EdgeInfo<int> { from = 4, to = 5, cost = 1 });

            network.NodeSet.FindByValue(2).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 2, cost = 4 });
            network.NodeSet.FindByValue(3).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 3, cost = 1 });
            network.NodeSet.FindByValue(3).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 3, cost = 3 });
            network.NodeSet.FindByValue(4).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 4, cost = 8 });
            network.NodeSet.FindByValue(4).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 4, cost = 2 });
            network.NodeSet.FindByValue(4).EdgeInfos.Add(new EdgeInfo<int> { from = 3, to = 4, cost = 2 });
            network.NodeSet.FindByValue(5).EdgeInfos.Add(new EdgeInfo<int> { from = 1, to = 5, cost = 10 });
            network.NodeSet.FindByValue(5).EdgeInfos.Add(new EdgeInfo<int> { from = 2, to = 5, cost = 6 });
            network.NodeSet.FindByValue(5).EdgeInfos.Add(new EdgeInfo<int> { from = 3, to = 5, cost = 3 });
            network.NodeSet.FindByValue(5).EdgeInfos.Add(new EdgeInfo<int> { from = 4, to = 5, cost = 1 });

            GraphNode<int> node1 = network.NodeSet.FindByValue(1);
            node1.Tag[0] = 0;
            node1.Tag[1] = 0;
            node1.IsTagPermanent = true;

            GraphNode<int> currentNode = null;
            for (int i = 0; i < network.NodeSet.Count; i++)
            {
                if (i == 0)
                    currentNode = network.NodeSet.FindByValue(1);
                else
                    currentNode = currentNode.ChangeTagToPermanent();

                foreach (var item in currentNode.Neighbours)
                {
                    item.Tag[0] = item.EdgeInfos.Where(x => (x.from == currentNode.Data || x.from == item.Data) && (x.to == item.Data || x.to == currentNode.Data)).Select(x => x.cost).First();
                    item.Tag[1] = currentNode.Data;
                    item.CurrentCost = item.Tag[0];
                }
            }

            //foreach (var node in network.NodeSet)
            //{
            //    foreach (var item in node.Neighbours)
            //    {
            //        if (item.IsTagPermanent == false)
            //        {
            //            item.Tag[0] = node.CurrentCost + node.EdgeInfos.Where(x => (x.from == node.Data || x.from == item.Data) && (x.to == item.Data || x.to == node.Data)).Select(x => x.cost).First();
            //            item.Tag[1] = node.Data;
            //            item.IsTagPermanent = false;
            //            item.CurrentCost = item.Tag[0];
            //        }
            //    }
            //}
            Console.ReadLine();
        }
    }
}
