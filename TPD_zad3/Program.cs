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

            //create tag for first node, mark it as permanent
            GraphNode<int> node1 = network.NodeSet.FindByValue(1);
            node1.Tag[0] = 0;
            node1.Tag[1] = 0;
            node1.IsTagPermanent = true;

            List<Summary> summaries = new List<Summary>();

            //main algorithm
            GraphNode<int> currentNode = null;
            for (int i = 0; i < network.NodeSet.Count; i++)
            {
                if (i == 0)
                    currentNode = network.NodeSet.FindByValue(1);
                else
                {
                    currentNode = currentNode.ChangeTagToPermanent();
                    summaries.Add(new Summary { Node = currentNode.Data, ShortestRoute = currentNode.VisitedNodes, Distance = currentNode.Tag[0] });
                }
                
                foreach (var item in currentNode.Neighbours)
                {
                    if (item.IsTagPermanent == false)
                    {
                        item.Tag[0] = currentNode.CurrentCost + item.EdgeInfos.Where(x => (x.from == currentNode.Data || x.from == item.Data) && (x.to == item.Data || x.to == currentNode.Data)).Select(x => x.cost).First();
                        item.Tag[1] = currentNode.Data;
                        item.CurrentCost = item.Tag[0];
                        item.VisitedNodes.Add(currentNode.Data);
                    }
                }
            }

            //order by node
            summaries = summaries.OrderBy(x => x.Node).ToList();

            //add last node to route
            foreach (var item in summaries)
            {
                item.ShortestRoute.Add(item.Node);
            }

            //print summary to console
            StringBuilder builder = new StringBuilder();
            foreach (var item in summaries)
            {
                builder.Append($"Węzeł: {item.Node}, Dystans: {item.Distance}, Najkrótsza droga: ");
                var last = item.ShortestRoute.Last();
                foreach (var route in item.ShortestRoute)
                {
                    if (route.Equals(last) == false)
                        builder.Append($"{route} - ");
                    else
                        builder.Append($"{route}");
                }
                builder.Append(Environment.NewLine);
            }
            Console.WriteLine(builder);
            Console.ReadLine();
        }
    }
}
