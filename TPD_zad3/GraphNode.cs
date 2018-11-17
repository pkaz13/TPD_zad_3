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
        public int[] Tag { get; set; }
        public bool IsTagPermanent { get; set; }
        public List<EdgeInfo<T>> EdgeInfos { get; set; }
        public int CurrentCost { get; set; }


        public GraphNode() { }
        public GraphNode(T data)
        {
            Data = data;
            Neighbours = new NodeList<T>();
            Tag = new int[2];
            IsTagPermanent = false;
            EdgeInfos = new List<EdgeInfo<T>>();
        }
        public GraphNode(T data, NodeList<T> neighbours)
        {
            Data = data;
            Neighbours = neighbours;
            Tag = new int[2];
            IsTagPermanent = false;
            EdgeInfos = new List<EdgeInfo<T>>();
        }

        public GraphNode<T> ChangeTagToPermanent()
        {
            var node = Neighbours.Where(x => x.Tag[0] == Neighbours.Where(y => y.IsTagPermanent == false).Min(y => y.Tag[0])).First();
            node.IsTagPermanent = true;
            return node;
        }
    }

    public struct EdgeInfo<T>
    {
        public T from;
        public T to;
        public int cost;
    }
}
