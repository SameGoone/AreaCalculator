using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator.Tests
{
    public class CircleTests
    {
        const string ZERO_NEGATIVE_RADIUS_ERROR = "The radius must be greater than 0";

        [Fact]
        public void ConstructCircleWithZeroRadius()
        {
            Action constructing = () => new Circle(0);
            AssertZeroNegativeRadiusException(constructing);
        }

        [Fact]
        public void ConstructCircleWithNegativeRadius()
        {
            Action constructing = () => new Circle(-1);
            AssertZeroNegativeRadiusException(constructing);
        }

        private void AssertZeroNegativeRadiusException(Action constructing)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(constructing);
            Assert.Equal(ZERO_NEGATIVE_RADIUS_ERROR, exception.Message);
        }
    }
}
