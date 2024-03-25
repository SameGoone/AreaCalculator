using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public class Triangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        const int CATHETUS_COUNT = 2;

        public override double Area
        {
            get
            {
                if (IsRight(out _, out var cathetus1, out var cathetus2))
                {
                    return cathetus1 * cathetus2 / 2;
                }
                else
                {
                    var p = Perimeter / 2;
                    return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                }
            }
        }

        public double Perimeter
        {
            get
            {
                return A + B + C;
            }
        }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0
                || b <= 0
                || c <= 0)
            {
                throw new ArgumentException("All sides must be greater than 0");
            }

            if (a >= b + c
                || b >= a + c
                || c >= a + b)
            {
                throw new ArgumentException("A triangle exists only when the sum of any two of its sides is greater than its third side");
            }

            A = a;
            B = b;
            C = c;
        }

        public bool IsRight(out double hypotenuse, out double cathetus1, out double cathetus2)
        {
            hypotenuse = 0;
            cathetus1 = 0;
            cathetus2 = 0;

            if (A == B && A == C)
            {
                return false;
            }

            double[] sides = { A, B, C };
            var max = sides.Max();
            var otherSides = sides
                .Where(s => s < max)
                .ToArray();

            if (otherSides.Length < CATHETUS_COUNT)
            {
                return false;
            }

            var isRight = Math.Pow(max, 2) == (Math.Pow(otherSides[0], 2) + Math.Pow(otherSides[1], 2));
            if (isRight)
            {
                hypotenuse = max;
                cathetus1 = otherSides[0];
                cathetus2 = otherSides[1];
            }
            return isRight;
        }
    }
}
