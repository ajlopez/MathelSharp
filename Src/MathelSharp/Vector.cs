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

        public IList<double> Elements
        {
            get
            {
                return new List<double>(this.elements);
            }
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
    }
}
