using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    public class NodeList<T> : Collection<GraphNode<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(GraphNode<T>));
        }

        public GraphNode<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (GraphNode<T> node in Items)
                if (node.Data.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
