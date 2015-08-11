namespace MathelSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        private double[][] elements;
        private int nrows;
        private int ncols;

        public Matrix(IList<IList<double>> elements)
            : this(elements, false)
        {
        }

        private Matrix(IList<IList<double>> elements, bool nocopy)
        {
            if (nocopy && elements is double[][])
                this.elements = (double[][])elements;
            else
            {
                this.elements = new double[elements.Count][];

                for (int k = 0; k < elements.Count; k++)
                    this.elements[k] = elements[k].ToArray();
            }

            this.nrows = this.elements.Length;
            this.ncols = this.elements[0].Length;
        }

        private Matrix(double[][] elements)
        {
            this.elements = elements;

            this.nrows = this.elements.Length;
            this.ncols = this.elements[0].Length;
        }

        public int Size { get { return this.elements.Length * this.elements[0].Length; } }

        public double[][] Elements 
        { 
            get 
            {
                double[][] newelements;

                newelements = new double[this.nrows][];

                for (int k = 0; k < this.nrows; k++)
                {
                    newelements[k] = new double[this.elements[k].Length];
                    Array.Copy(this.elements[k], newelements[k], this.ncols);
                }

                return newelements; 
            }
        }

        public static Matrix Unity(int nrows)
        {
            double[][] elements = new double[nrows][];

            for (int k = 0; k < nrows; k++)
            {
                elements[k] = new double[nrows];
                elements[k][k] = 1.0;
            }

            return new Matrix(elements, true);
        }

        public double GetElement(int nrow, int ncol)
        {
            return this.elements[nrow][ncol];
        }

        public Matrix Negate()
        {
            var newelements = this.Elements;

            for (int k = 0; k < this.nrows; k++)
                for (int j = 0; j < this.ncols; j++)
                    newelements[k][j] = -newelements[k][j];

            return new Matrix(newelements);
        }

        public Matrix Add(Matrix matrix)
        {
            if (this.nrows != matrix.nrows || this.ncols != matrix.ncols)
                throw new InvalidOperationException("Matrices have different sizes");

            double[][] newelements = new double[this.nrows][];

            for (int k = 0; k < this.nrows; k++)
            {
                newelements[k] = new double[this.ncols];

                for (int j = 0; j < this.ncols; j++)
                    newelements[k][j] = this.elements[k][j] + matrix.elements[k][j];
            }

            return new Matrix(newelements);
        }

        public Matrix Subtract(Matrix matrix)
        {
            double[][] newelements = new double[this.nrows][];

            for (int k = 0; k < this.nrows; k++)
            {
                newelements[k] = new double[this.ncols];

                for (int j = 0; j < this.ncols; j++)
                    newelements[k][j] = this.elements[k][j] - matrix.elements[k][j];
            }

            return new Matrix(newelements);
        }

        public Matrix Multiply(Matrix matrix)
        {
            double[][] newelements = new double[this.nrows][];

            for (int k = 0; k < this.nrows; k++)
            {
                newelements[k] = new double[matrix.ncols];

                for (int j = 0; j < matrix.ncols; j++)
                {
                    double sum = 0.0;

                    for (int l = 0; l < this.ncols; l++)
                        sum += this.elements[k][l] * matrix.elements[l][j];

                    newelements[k][j] = sum;
                }
            }

            return new Matrix(newelements);
        }

        public double Determinant()
        {
            bool[] columns = new bool[this.ncols];
            int size = 0;

            return this.Determinant(size, columns);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix matrix = (Matrix)obj;

            if (this.nrows != matrix.nrows)
                return false;

            if (this.ncols != matrix.ncols)
                return false;

            for (int k = 0; k < this.nrows; k++)
                for (int j = 0; j < this.ncols; j++)
                    if (this.elements[k][j] != matrix.elements[k][j])
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            int result = this.nrows.GetHashCode() + (17 * this.ncols.GetHashCode());

            for (int k = 0; k < this.nrows; k++)
                for (int j = 0; j < this.ncols; j++)
                {
                    result *= 17;
                    result += this.elements[k][j].GetHashCode();
                }

            return result;
        }

        private double Determinant(int size, bool[] columns)
        {
            int ncolumn = 0;
            bool last = size + 1 >= this.ncols;

            double result = 0.0;

            for (int k = 0; k < this.ncols; k++)
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
