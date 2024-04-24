using System;

namespace IZ1
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

        static bool FindObj(Node root, double data)
        {
            if (root == null)
                return false;
            return root.data == data || FindObj(root.left, data) || FindObj(root.right, data);
        }

        static void Main(string[] args)
        {
            Node root = new Node(5);
            double[] mas = new double[] {2,6,4,7,8,1 };
            for(int i=0; i<mas.Length; i++)
            {
                PushNode(root, new Node(mas[i]));
            }



            Console.WriteLine(FindObj(root, 3));

            Console.ReadLine();
        }
    }
}
