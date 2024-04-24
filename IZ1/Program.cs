using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

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

        static Node MakeTree(double[] mas)
        {
            Node root = new Node(mas[0]);
            for (int i = 1; i < mas.Length; i++)
            {
                PushNode(root, new Node(mas[i]));
            }
            return root;
        }

        //Идеальное дерево{
        //T(n) = 3 + T((n-1)/2) + T((n-1)/2)
        //T(0) = 2
        //min(T(n)) = 3
        //max(T(n)) = 3 + (n-1)*5 + n*3
        //}

        //Вырожденное дерево{
        //T(n) = 3 + T(n-1) + T(0)
        //T(0) = 2
        //min(T(n)) = 3
        //max(T(n)) = 3 + n*3 + (n-1)*5
        //}
        static bool FindObj(Node root, double data)
        {
            if (root == null)
                return false;
            return root.data == data || FindObj(root.left, data) || FindObj(root.right, data);
        }   

        static void Main(string[] args)
        {
            List<double[]> fullTrees = new List<double[]>
            {
                new double[]{1},
                new double[]{2,1,3 },
                new double[] { 4, 2, 1, 3, 6, 5, 7 },
                new double[] { 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15 }
            };

            List<double[]> degenTrees = new List<double[]>
            {
                new double[]{1 },
                new double[] {1,2,3},
                new double[] {1,2,3,4,5,6,7 },
                new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15}
            };

            Stopwatch stopwatch = Stopwatch.StartNew();
            FindObj(null, -1);
            stopwatch.Stop();
            stopwatch.Reset();
            
            for(int i=0; i<fullTrees.Count; i++)
            {
                Node fullRoot = MakeTree(fullTrees[i]);
                Node degenRoot = MakeTree(degenTrees[i]);

                stopwatch.Reset();
                stopwatch.Start();
                FindObj(fullRoot, fullTrees[i][0]);
                stopwatch.Stop();
                Console.WriteLine($"Количество вершин n:  {fullTrees[i].Length}");
                Console.Write($"min(T(n)) для идеального дерева:  {stopwatch.ElapsedTicks}\t\t");

                stopwatch.Reset();
                stopwatch.Start();
                FindObj(degenRoot, degenTrees[i][0]);
                stopwatch.Stop();
                Console.Write($"min(T(n)) для вырожденного дерева:  {stopwatch.ElapsedTicks}\n");

                stopwatch.Reset();
                stopwatch.Start();
                FindObj(fullRoot, -1);
                stopwatch.Stop();
                Console.Write($"max(T(n)) для идеального дерева:  {stopwatch.ElapsedTicks}\t\t");

                stopwatch.Reset();
                stopwatch.Start();
                FindObj(degenRoot, -1);
                stopwatch.Stop();
                Console.Write($"max(T(n)) для вырожденного дерева:  {stopwatch.ElapsedTicks}\n\n");
            }

            Console.ReadLine();
        }
    }
}
