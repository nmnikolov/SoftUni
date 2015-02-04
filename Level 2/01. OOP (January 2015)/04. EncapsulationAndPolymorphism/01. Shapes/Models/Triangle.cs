namespace Shape.Models
{
    using System;

    public class Triangle : BasicShape
    {
        private double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
            : base(firstSide, secondSide)
        {
            this.ThirdSide = thirdSide;
        }

        public double ThirdSide
        {
            get { return this.thirdSide; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("thirdSide", "Size should be greater than 0.");
                }

                this.thirdSide = value;
            }
        }

        public override double CalculateArea()
        {
            double p = (this.Width + this.Height + this.ThirdSide) / 2;
            double area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.ThirdSide));

            if (Double.IsNaN(area))
            {
                throw new ArgumentException("Not a Triangle if one side is bigger than the other two combined");
            }

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.ThirdSide;

            return perimeter;
        }
    }
}