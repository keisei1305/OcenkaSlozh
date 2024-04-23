using System;
using System.Collections.Generic;

namespace Лаба1
{
    class Program
    {
        //T(n) = 3n+1 = min(n) = max(n) 
        double scalar_multiplication(Vector vector1, Vector vector2)
        {
            int n = vector1.Array.Count;
            double sum = 0;
            for (int i = 0; i < n; i++)
                sum += vector1[i] * vector2[i];
            return sum;
        }
        //T(n) = 3n^3 + 1 = min(n) = max(n) 
        List<Vector> matrix_multiplication(List<Vector> matrix1, List<Vector> matrix2)
        {
            int n = matrix1.Count;
            List<Vector> resultMatrix = new List<Vector>(n);
            for(int i=0; i<n; i++)
            {
                resultMatrix[i] = new Vector(n);
            }
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    for(int k=0; k<n; k++)
                    {
                        resultMatrix[i][j] += matrix1[i][k] * matrix2[k][j];
                    }
                }
            }

            return resultMatrix;
        }
      
        //T(n) = (n-1) (2+n/2+1)/2 + (n-1) (2+3n/2+4) /2 = (n-1)(n+4.5) T(2) = 6.5
        // min(n) = (n-1)(2+n/2+1)
        // max(n) = (n-1)(2+3n/2+4)
        void selection_sort(List<double> list)
        {
            int n = list.Count;
            for(int i=0; i<n-1; i++)
            {
                double m = list[i];
                int p = i;
                for(int j=i+1; j<n; j++)
                {
                    if (m > list[j])
                    {
                        m = list[j];
                        p = j;
                    }
                }

                if (p != i)
                {
                    double temp = list[i];
                    list[i] = list[p];
                    list[p] = temp;
                }
            }
        }
        //T(n) = 2(n-1) ^2
        //min(n) 2(n-1) 
        //max(n) 4(n-1)^2
        void insertion_sort(List<double> list)
        {
            int n = list.Count;
            for(int i=1; i<n; i++)
            {
                for(int j=i; j>0; j--)
                {
                    if (list[j] < list[j - 1])
                    {
                        double temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = list[j];
                    }
                    else
                        break;
                }
            }
        }

        //T(n) = (n-1)n/4 + 2(n-1) n/2
        //max(n)  = (n-1)(n/2 * 4) 
        //min(n) = (n-1)n / 2
        void bubble_sort(List<double> list)
        {
            int n = list.Count;
            for(int i=0; i<n-1; i++)
            {
                for(int j=0; j < n - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {

                        double temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = list[j];
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
