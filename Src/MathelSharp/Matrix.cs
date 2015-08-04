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

        public double[][] Elements 
        { 
            get 
            {
                double[][] newelements;

                newelements = new double[this.elements.Length][];

                for (int k = 0; k < this.elements.Length; k++)
                {
                    newelements[k] = new double[this.elements[k].Length];
                    Array.Copy(this.elements[k], newelements[k], newelements[k].Length);
                }

                return newelements; 
            }
        }

        public double GetElement(int nrow, int ncol)
        {
            return this.elements[nrow][ncol];
        }

        public Matrix Negate()
        {
            var newelements = this.Elements;

            for (int k = 0; k < newelements.Length; k++)
                for (int j = 0; j < newelements[k].Length; j++)
                    newelements[k][j] = -newelements[k][j];

            return new Matrix(newelements);
        }

        public Matrix Add(Matrix matrix)
        {
            double[][] newelements = new double[this.Elements.Length][];

            for (int k = 0; k < newelements.Length; k++)
            {
                newelements[k] = new double[this.elements[k].Length];

                for (int j = 0; j < this.elements[k].Length; j++)
                    newelements[k][j] = this.elements[k][j] + matrix.elements[k][j];
            }

            return new Matrix(newelements);
        }

        public Matrix Subtract(Matrix matrix)
        {
            double[][] newelements = new double[this.Elements.Length][];

            for (int k = 0; k < newelements.Length; k++)
            {
                newelements[k] = new double[this.elements[k].Length];

                for (int j = 0; j < this.elements[k].Length; j++)
                    newelements[k][j] = this.elements[k][j] - matrix.elements[k][j];
            }

            return new Matrix(newelements);
        }

        public Matrix Multiply(Matrix matrix)
        {
            double[][] newelements = new double[this.Elements.Length][];

            for (int k = 0; k < newelements.Length; k++)
            {
                newelements[k] = new double[matrix.elements[k].Length];

                for (int j = 0; j < matrix.elements[0].Length; j++)
                {
                    double sum = 0.0;

                    for (int l = 0; l < this.elements[k].Length; l++)
                        sum += this.elements[k][l] * matrix.elements[l][j];

                    newelements[k][j] = sum;
                }
            }

            return new Matrix(newelements);
        }

        public double Determinant()
        {
            bool[] columns = new bool[this.elements[0].Length];
            int size = 0;

            return this.Determinant(size, columns);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix matrix = (Matrix)obj;

            if (this.elements.Length != matrix.elements.Length)
                return false;
            if (this.elements[0].Length != matrix.elements[0].Length)
                return false;

            for (int k = 0; k < this.elements.Length; k++)
                for (int j = 0; j < this.elements[0].Length; j++)
                    if (this.elements[k][j] != matrix.elements[k][j])
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = this.elements.Length.GetHashCode() + (17 * this.elements[0].Length.GetHashCode());

            for (int k = 0; k < this.elements.Length; k++)
                for (int j = 0; j < this.elements[0].Length; j++)
                {
                    result *= 17;
                    result += this.elements[k][j].GetHashCode();
                }

            return result;
        }

        private double Determinant(int size, bool[] columns)
        {
            int ncolumn = 0;
            int ncols = this.elements[0].Length;
            bool last = size + 1 >= ncols;

            double result = 0.0;

            for (int k = 0; k < ncols; k++)
            {
                if (columns[k])
                    continue;

                if (last)
                    return this.elements[size][k];

                columns[k] = true;
                double value = this.Determinant(size + 1, columns) * this.elements[size][k];
                columns[k] = false;

                if ((size + k) % 2 == 1)
                    value = -value;

                result += value;

                ncolumn++;
            }

            return result;
        }
    }
}
