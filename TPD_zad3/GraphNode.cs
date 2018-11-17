using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;

        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();
                return costs;
            }
        }

        public new NodeList<T> Neighbours
        {
            get
            {
                if (base.Neighbours == null)
                    base.Neighbours = new NodeList<T>();

                return base.Neighbours;
            }
        }

        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }
    }
}
