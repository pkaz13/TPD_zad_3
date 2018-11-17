using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    public class Graph<T>
    {
        public NodeList<T> NodeSet { get; set; }

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
                NodeSet = new NodeList<T>();
            else
                NodeSet = nodeSet;
        }

        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            NodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            // adds a node to the graph
            NodeSet.Add(new GraphNode<T>(value));
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.Neighbours.Add(to);
            to.Neighbours.Add(from);
        }

        public bool Contains(T value)
        {
            return NodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)NodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            NodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in NodeSet)
            {
                int index = gnode.Neighbours.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbours.RemoveAt(index);
                }
            }

            return true;
        }
    }
}
