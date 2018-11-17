using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPD_zad3
{
    public class Node<T>
    {
        public T Data { get; set; }
        public NodeList<T> Neighbours { get; set; }

        public Node() { }

        public Node(T data) : this(data, null) { }

        public Node(T data, NodeList<T> neighbours)
        {
            Data = data;
            Neighbours = neighbours;
        }
    }
}
