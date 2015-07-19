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
    }
}
