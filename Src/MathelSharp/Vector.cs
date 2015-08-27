namespace MathelSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Vector
    {
        private double[] elements;
        private int size;

        public Vector(IList<double> elements)
        {
            this.elements = elements.ToArray();
            this.size = this.elements.Length;
        }

        public Vector(int size, double value)
        {
            this.elements = new double[size];
            this.size = size;

            for (int k = 0; k < size; k++)
                this.elements[k] = value;
        }

        public int Size { get { return this.size; } }

        public double[] Elements
        {
            get
            {
                double[] result = new double[this.size];
                Array.Copy(this.elements, result, this.size);
                return result;
            }
        }

        public double GetElement(int n)
        {
            return this.elements[n];
        }

        public Vector Negate()
        {
            double[] newelements = new double[this.size];

            for (int k = 0; k < this.size; k++)
                newelements[k] = -this.elements[k];

            return new Vector(newelements);
        }

        public Vector Add(Vector vector)
        {
            if (this.size != vector.size)
                throw new InvalidOperationException("Vectors have different lengths");

            double[] newelements = new double[this.size];

            for (int k = 0; k < this.size; k++)
                newelements[k] = this.elements[k] + vector.elements[k];

            return new Vector(newelements);
        }

        public Vector Subtract(Vector vector)
        {
            if (this.size != vector.size)
                throw new InvalidOperationException("Vectors have different lengths");

            double[] newelements = new double[this.size];

            for (int k = 0; k < this.size; k++)
                newelements[k] = this.elements[k] - vector.elements[k];

            return new Vector(newelements);
        }

        public Vector Multiply(double number)
        {
            double[] newelements = new double[this.size];

            for (int k = 0; k < this.size; k++)
                newelements[k] = this.elements[k] * number;

            return new Vector(newelements);
        }

        public double InnerProduct(Vector vector)
        {
            if (this.size != vector.size)
                throw new InvalidOperationException("Vectors have different lengths");

            double result = 0.0;

            for (int k = 0; k < this.size; k++)
                result += this.elements[k] * vector.elements[k];

            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
                return false;

            Vector vector = (Vector)obj;

            if (this.size != vector.size)
                return false;

            for (int k = 0; k < this.size; k++)
                if (this.elements[k] != vector.elements[k])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = this.size.GetHashCode();

            for (int k = 0; k < this.size; k++)
            {
                result *= 17;
                result += this.elements[k].GetHashCode();
            }

            return result;
        }
    }
}
