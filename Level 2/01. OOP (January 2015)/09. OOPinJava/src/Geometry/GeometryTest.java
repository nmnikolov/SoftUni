package Geometry;

import Geometry.Interfaces.VolumeMeasurable;
import Geometry.Shapes.PlaneShapes.Circle;
import Geometry.Shapes.PlaneShapes.PlaneShape;
import Geometry.Shapes.PlaneShapes.Rectangle;
import Geometry.Shapes.PlaneShapes.Triangle;
import Geometry.Shapes.Shape;
import Geometry.Shapes.SpaceShapes.Cuboid;
import Geometry.Shapes.SpaceShapes.Sphere;
import Geometry.Shapes.SpaceShapes.SquarePyramid;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class GeometryTest {

    public static void main(String[] args) throws Exception{
        try {
            Triangle triangle = new Triangle(new double[]{15, 15}, new double[]{23, 30}, new double[]{50, 25});
            Rectangle rectangle = new Rectangle(new double[]{15, 15}, 15, 15);
            Circle circle = new Circle(new double[]{15, 15}, 3);
            SquarePyramid squarePyramid = new SquarePyramid(new double[]{1, 2, 3}, 4, 6);
            Cuboid cuboid = new Cuboid(new double[]{1, 2, 3}, 10, 5, 4);
            Sphere sphere = new Sphere(new double[]{1, 2, 3}, 10);

            List<Shape> shapes = Arrays.asList(triangle, rectangle, circle, squarePyramid, cuboid, sphere);

            System.out.println("<-----Print all shapes----->\n");
            shapes.forEach(System.out::println);

            System.out.println("<-----Sort Plane shapes by perimeter----->\n");
            List<PlaneShape> filterByPerimeter = shapes.stream()
                    .filter(s -> s instanceof PlaneShape)
                    .map(s -> (PlaneShape) s)
                    .sorted((p1, p2) -> Double.compare(p1.getPerimeter(), p2.getPerimeter()))
                    .collect(Collectors.toList());
            filterByPerimeter.forEach(System.out::println);

            System.out.println("<-----VolumeMeasurable shapes whose volume is over 40.00----->\n");
            List<VolumeMeasurable> filterByVolume = shapes.stream()
                    .filter(s -> s instanceof VolumeMeasurable)
                    .map(s -> (VolumeMeasurable) s)
                    .filter(s -> s.getVolume() > 40.0)
                    .collect(Collectors.toList());
            filterByVolume.forEach(System.out::println);
        } catch (Exception ex){
            System.err.println(ex);
        }
    }
}