using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба1
{
    internal class Vector
    {
        private List<double> array;

        public List<double> Array
        {
            get => array;
        }

        #region Construct
        public Vector()
        {
            array = new List<double>();
        }

        public Vector(int n)
        {
            array = new List<double>(n);
            for(int i=0; i<n; i++)
            {
                array[i] = 0;
            }
        }

        public Vector(List<double> list)
        {
            array = new List<double>(list);
        }
        public Vector(double[] list)
        {
            array = new List<double>(list);
        }

        public Vector(Vector vector)
        {
            array = new List<double>(vector.array);
        }
        #endregion construct

        public double this[int i]
        {
            get
            {
                if (i >= array.Count || i < 0) throw new IndexOutOfRangeException();
                return array[i];
            }
            set
            {
                if (i >= array.Count || i < 0) throw new IndexOutOfRangeException();
                array[i] = value;
            }
        }

        public Vector Normalize()
        {
            return this / Norm();
        }

        public double Norm()
        {
            double result = 0;
            for (int i = 0; i < array.Count; i++)
            {
                result += array[i] * array[i];
            }
            return Math.Sqrt(result);
        }

        static public Vector operator -(Vector vector1, Vector vector2)
        {
            if (vector1.array.Count != vector2.array.Count) throw new Exception(message: "Разные размеры векторов");
            Vector resultVector = new Vector(vector1);
            for (int i = 0; i < vector1.array.Count; i++)
            {
                resultVector[i] -= vector2[i];
            }
            return resultVector;
        }

        static public Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.array.Count != vector2.array.Count) throw new Exception(message: "Разные размеры векторов");
            Vector resultVector = new Vector(vector1);
            for (int i = 0; i < vector1.array.Count; i++)
            {
                resultVector[i] += vector2[i];
            }
            return resultVector;
        }

        static public double operator *(Vector vector1, Vector vector2)
        {
            if (vector1.array.Count != vector2.array.Count) throw new Exception(message: "Разные размеры векторов");
            double result = 0;
            for (int i = 0; i < vector1.array.Count; i++)
            {
                result += vector1[i] * vector2[i];
            }
            return result;
        }

        static public Vector operator *(Vector vector1, double v)
        {
            Vector resultVector = new Vector(vector1);
            for (int i = 0; i < resultVector.array.Count; i++)
            {
                resultVector[i] *= v;
            }
            return resultVector;
        }

        static public Vector operator *(double v, Vector vector1)
        {
            Vector resultVector = new Vector(vector1);
            for (int i = 0; i < resultVector.array.Count; i++)
            {
                resultVector[i] *= v;
            }
            return resultVector;
        }

        static public Vector operator /(Vector vector1, double v)
        {
            Vector resultVector = new Vector(vector1);
            for (int i = 0; i < resultVector.array.Count; i++)
            {
                resultVector[i] /= v;
            }
            return resultVector;
        }
    }
}