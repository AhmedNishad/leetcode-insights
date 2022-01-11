using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Algorithms.Graph.CloneGraph
{
    public class CloneGraph
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        /// <summary>
        /// Used to replace the program main method to test out the cases
        /// </summary>
        public static void Test()
        {
            var node = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            node2.neighbors = new List<Node> { node, node4 };
            node4.neighbors = new List<Node> { node2, node3 };
            node3.neighbors = new List<Node> { node, node4 };

            node.neighbors.Add(node2);
            node.neighbors.Add(node3);
            CloneGraphDFS(node);
        }
        public static Node CloneGraphDFS(Node node)
        {
            Dictionary<Node, Node> hm = new Dictionary<Node, Node>();
            var c = Clone(node, hm);
            return c;
        }

        public static Node Clone(Node node, Dictionary<Node, Node> hm)
        {
            Node existingNode = null;
            if (!hm.TryGetValue(node, out existingNode))
            {
                var copy = new Node(node.val);
                hm[node] = copy;

                foreach (var n in node.neighbors)
                {
                    copy.neighbors.Add(Clone(n, hm));
                }

                return copy;

            }
            else
            {
                return existingNode;
            }
        }

        public static Node CloneGraphFn(Node node)
        {
            Dictionary<Node, Node> hm = new Dictionary<Node, Node>();

            var newStartNode = new Node(node.val);
            hm[node] = newStartNode;

            foreach (var neighbor in node.neighbors)
            {
                var neighbourNode = new Node(neighbor.val);
                foreach (var nestedNeighbour in neighbor.neighbors)
                {
                    Node existingNode = null;
                    if (!hm.TryGetValue(nestedNeighbour, out existingNode))
                    {
                        existingNode = new Node(nestedNeighbour.val);
                        hm[nestedNeighbour] = existingNode;
                    }
                    neighbourNode.neighbors.Add(existingNode);
                }
                newStartNode.neighbors.Add(neighbourNode);
            }

            if (node.neighbors.Count == 0)
                return new Node(node.val);

            return new Node();
        }
    }
}
