namespace Shape.Models
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;

            return area;
        }

        public override double CalculatePerimeter()
        {
            var perimeter = (this.Width * 2) + (this.Height * 2);

            return perimeter;
        }
    }
}