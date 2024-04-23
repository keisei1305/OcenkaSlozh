using System;
using System.Collections.Generic;

namespace Лаба2
{
    class Program
    {
        class Node
        {
            public double data;
            public Node left;
            public Node right;
            public Node(double data)
            {
                this.data = data;
                this.right = null;
                this.left = null;
            }
        }

        static void PushNode(Node root, Node obj)
        {
            if (root is null) return;

            if (obj.data == root.data) return;

            if (obj.data > root.data)
            {
                if (!(root.right is null))
                {
                    PushNode(root.right, obj);
                }
                else
                {
                    root.right = obj;
                    return;
                }
            }

            if (obj.data < root.data)
            {
                if (!(root.left is null))
                {
                    PushNode(root.left, obj);
                }
                else
                {
                    root.left = obj;
                    return;
                }
            }
        }
        // min(n) = 3 + n*(1+2+2+2+1)
        // max(n) = 3 + log2(n+1)*(1+log2(n+1)*(2+2+2)+1)   
        static int not_recursive(Node root)
        {
            Node p = root;
            List<Node> v = new List<Node>() { p};
            int count = 0;
            while (v.Count!=0)
            {
                List<Node> vn = new List<Node>();
                foreach(Node x in v)
                {
                    count++;
                    if (!(x.left is null))
                        vn.Add(x.left);
                    if (!(x.right is null))
                        vn.Add(x.right);
                }
                v = vn;
            }
            return count;
        }

        //T(n) = 6*(2^n)-5
        static int recursive(Node root)
        {
            if (root is null)
                return 0;
            return 1 + recursive(root.left) + recursive(root.right);
        }

        static void Main(string[] args)
        {
            List<double> v = new List<double> { 10, 5, 7, 16, 13, 2, 20 };
            Node root = new Node(v[0]);

            foreach (var x in v)
            {
                PushNode(root, new Node(x));
            }

            Console.WriteLine(recursive(root));
            Console.WriteLine(not_recursive(root));
        }
    }
}
