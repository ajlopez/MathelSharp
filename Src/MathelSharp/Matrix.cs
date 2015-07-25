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
    }
}
