using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Tests
{
    public class TriangleTests
    {
        const string ZERO_NEGATIVE_SIDES_ERROR = "All sides must be greater than 0";
        const string NON_EXISTABLE_SIDES_ERROR = "A triangle exists only when the sum of any two of its sides is greater than its third side";

        [Fact]
        public void ConstructTriangleWithZeroSides()
        {
            Action[] constructings =
            {
                () => new Triangle(0, 3, 5), // Zero A
                () => new Triangle(4, 0, 5), // Zero B
                () => new Triangle(6, 3, 0), // Zero C
                () => new Triangle(0, 0, 0) // Zero all
            };

            foreach (Action constructing in constructings)
            {
                AssertZeroNegativeSidesException(constructing);
            }
        }

        [Fact]
        public void ConstructTriangleWithNegativeSides()
        {
            Action[] constructings =
            {
                () => new Triangle(-4, 3, 5), // Negative A
                () => new Triangle(4, -2, 5), // Negative B
                () => new Triangle(6, 3, -3), // Negative C
                () => new Triangle(-1, -1, -1) // Negative all
            };

            foreach (Action constructing in constructings)
            {
                AssertZeroNegativeSidesException(constructing);
            }
        }

        private void AssertZeroNegativeSidesException(Action constructing)
        {
            AssertConstructingException(constructing, ZERO_NEGATIVE_SIDES_ERROR);
        }

        [Fact]
        public void ConstructTriangleWithNonExistableSides()
        {
            Action[] constructings =
            {
                () => new Triangle(10, 4, 3), // Very big A
                () => new Triangle(3, 7, 4), // Very big B
                () => new Triangle(3, 4, 8), // Very big C
            };

            foreach (Action constructing in constructings)
            {
                AssertNonExistableSidesException(constructing);
            }
        }

        private void AssertNonExistableSidesException(Action constructing)
        {
            AssertConstructingException(constructing, NON_EXISTABLE_SIDES_ERROR);
        }

        private void AssertConstructingException(Action constructing, string exceptionMessage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(constructing);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Fact]
        public void CalculatePerimeter()
        {
            var triangle = new Triangle(4, 6, 8);
            var expected = 18;

            var actual = triangle.Perimeter;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateIsRightForRight()
        {
            var a = 3;
            var b = 4;
            var c = 5;
            var triangle = new Triangle(a, b, c);
            var expected = true;

            var actual = triangle.IsRight(out var hypotenuse, out var cathetus1, out var cathetus2);

            Assert.Equal(expected, actual);
            Assert.Equal(hypotenuse, c);
            Assert.Equal(cathetus1, a);
            Assert.Equal(cathetus2, b);
        }

        [Fact]
        public void CalculateIsRightForNonRight()
        {
            var empty = 0d;
            var a = 3;
            var b = 4;
            var c = 6;
            var triangle = new Triangle(a, b, c);
            var expected = false;

            var actual = triangle.IsRight(out var hypotenuse, out var cathetus1, out var cathetus2);

            Assert.Equal(expected, actual);
            Assert.Equal(hypotenuse, empty);
            Assert.Equal(cathetus1, empty);
            Assert.Equal(cathetus2, empty);
        }

        [Fact]
        public void CalculateAreaForRight()
        {
            var triangle = new Triangle(3, 4, 5);
            var expected = 6;

            var actual = triangle.Area;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateAreaForNonRight()
        {
            var triangle = new Triangle(4, 5, 8);
            var expected = 8.181534;

            var actual = Math.Round(triangle.Area, 6);

            Assert.Equal(expected, actual);
        }
    }
}
