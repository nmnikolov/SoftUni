package Geometry.Shapes.PlaneShapes;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(double[] vertex, double radius) throws Exception{
        this.setVertices(vertex);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    public void setRadius(double radius) throws Exception{
        if (radius <= 0){
            throw new Exception("Radius should be greater than 0");
        }

        this.radius = radius;
    }

    @Override
    public double getArea() {
        double area = Math.PI * Math.pow(this.getRadius(), 2);

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2 * Math.PI * this.getRadius();

        return perimeter;
    }

    @Override
    public String toString() {
        String result = "Circle:\n";
        result += String.format("Vertex: x=%.2f y=%.2f\n", this.getVertices().get(0)[0], this.getVertices().get(0)[1]);
        result += String.format("Radius: %.2f\n", this.getRadius());
        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Perimeter: %.2f\n", this.getPerimeter());

        return result;
    }
}