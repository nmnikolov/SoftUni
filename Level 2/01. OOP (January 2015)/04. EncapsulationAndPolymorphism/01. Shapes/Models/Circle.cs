namespace Shape.Models
{
    using System;
    using Interfaces;

    public class Circle : BasicShape
    {
        public Circle(double radius)
            : base(radius, 1)
        {
        }

        public override double CalculateArea()
        {
            double area = Math.PI * this.Width * this.Width;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = Math.PI * this.Width * 2;

            return perimeter;
        }
    }
}