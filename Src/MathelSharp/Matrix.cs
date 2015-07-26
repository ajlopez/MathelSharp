namespace MathelSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        private double[][] elements;

        public Matrix(IList<IList<double>> elements)
        {
            this.elements = new double[elements.Count][];

            for (int k = 0; k < elements.Count; k++)
                this.elements[k] = elements[k].ToArray();
        }

        private Matrix(double[][] elements)
        {
            this.elements = elements;
        }

        public int Size { get { return this.elements.Length * this.elements[0].Length; } }

        public double[][] Elements { 
            get 
            {
                double[][] newelements;

                newelements = new double[this.elements.Length][];

                for (int k = 0; k < this.elements.Length; k++) {
                    newelements[k] = new double[this.elements[k].Length];
                    Array.Copy(this.elements[k], newelements[k], newelements[k].Length);
                }

                return newelements; 
            }
        }

        public Matrix Negate()
        {
            var newelements = this.Elements;

            for (int k = 0; k < newelements.Length; k++)
                for (int j = 0; j < newelements[k].Length; j++)
                    newelements[k][j] = -newelements[k][j];

            return new Matrix(newelements);
        }
    }
}
