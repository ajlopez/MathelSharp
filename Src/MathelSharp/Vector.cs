namespace MathelSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vector
    {
        private double[] elements;

        public Vector(IList<double> elements)
        {
            this.elements = elements.ToArray();
        }

        public int Size { get { return this.elements.Length; } }

        public double[] Elements
        {
            get
            {
                double[] result = new double[this.elements.Length];
                Array.Copy(this.elements, result, result.Length);
                return result;
            }
        }

        public double GetElement(int n)
        {
            return this.elements[n];
        }

        public Vector Negate()
        {
            int size = this.elements.Length;
            double[] newelements = new double[size];

            for (int k = 0; k < size; k++)
                newelements[k] = -this.elements[k];

            return new Vector(newelements);
        }

        public Vector Add(Vector vector)
        {
            int size = this.elements.Length;
            double[] newelements = new double[size];

            for (int k = 0; k < size; k++)
                newelements[k] = this.elements[k] + vector.elements[k];

            return new Vector(newelements);
        }

        public Vector Subtract(Vector vector)
        {
            int size = this.elements.Length;
            double[] newelements = new double[size];

            for (int k = 0; k < size; k++)
                newelements[k] = this.elements[k] - vector.elements[k];

            return new Vector(newelements);
        }

        public double InnerProduct(Vector vector)
        {
            double result = 0.0;
            int size = this.elements.Length;

            for (int k = 0; k < size; k++)
                result += this.elements[k] * vector.elements[k];

            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;

            Vector vector = (Vector)obj;

            if (this.elements.Length != vector.elements.Length)
                return false;

            for (int k = 0; k < this.elements.Length; k++)
                if (this.elements[k] != vector.elements[k])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = this.elements.Length.GetHashCode();

            for (int k = 0; k < this.elements.Length; k++)
            {
                result *= 17;
                result += this.elements[k].GetHashCode();
            }

            return result;
        }
    }
}
