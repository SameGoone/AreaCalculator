using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public class Circle : Figure
    {
        public double Radius { get; set; }

        public override double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be greater than 0");
            }

            Radius = radius;
        }
    }
}
