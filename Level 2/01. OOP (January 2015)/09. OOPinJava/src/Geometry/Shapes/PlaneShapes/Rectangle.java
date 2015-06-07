package Geometry.Shapes.PlaneShapes;

public class Rectangle extends PlaneShape{
    private double width;
    private double height;

    public Rectangle(double[] vertex, double width, double height) throws Exception{
        this.setVertices(vertex);
        this.setWidth(width);
        this.setHeight(height);
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) throws Exception{
        if (width <= 0){
            throw new Exception("Width should be greater than 0.");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) throws Exception{
        if (height <= 0){
            throw new Exception("Height should be greater than 0.");
        }

        this.height = height;
    }

    @Override
    public double getArea() {
        double area = this.getHeight() * this.getHeight();

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getWidth() * 2 + this.getHeight() * 2;

        return perimeter;
    }

    @Override
    public String toString() {
        String result = "Rectangle:\n";
        result += String.format("Vertex: x=%.2f y=%.2f\n", this.getVertices().get(0)[0], this.getVertices().get(0)[1]);
        result += String.format("Width: %.2f\n", this.getWidth());
        result += String.format("Height: %.2f\n", this.getHeight());
        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Perimeter: %.2f\n", this.getPerimeter());

        return result;
    }
}