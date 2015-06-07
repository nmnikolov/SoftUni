namespace Shape
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ShapesTest
    {
        public static void Main()
        {
            try
            {
                IList<BasicShape> shapes = new List<BasicShape>()
                {
                    new Circle(1.6),
                    new Circle(5.2),
                    new Rectangle(3, 1.5),
                    new Rectangle(6.9, 6.1),
                    new Triangle(1.5, 2.0, 3.3),
                    new Triangle(6.8, 9.4, 3.5)
                };

                shapes.ToList().ForEach(shape =>
                {
                    Console.WriteLine("Shape: {0}\nArea: {1:N2}\nPerimeter: {2:N2}\n", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
                });
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}