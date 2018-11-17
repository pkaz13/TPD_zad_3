using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    public class GraphNode<T>
    {
        public T Data { get; set; }
        public NodeList<T> Neighbours { get; set; }

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

        public GraphNode() { }
        public GraphNode(T data)
        {
            Data = data;
            Neighbours = new NodeList<T>();
        }
        public GraphNode(T data, NodeList<T> neighbours)
        {
            Data = data;
            Neighbours = neighbours;
        }
    }
}
