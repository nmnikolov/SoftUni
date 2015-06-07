package Geometry.Shapes.SpaceShapes;

public class Cuboid extends SpaceShape
{
    private double width;
    private double height;
    private double depth;

    public Cuboid(double[] vertex, double width, double height, double depth) throws Exception{
        this.setVertices(vertex);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
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

    public double getDepth() {

        return this.depth;
    }

    public void setDepth(double depth) throws Exception{
        if (depth <= 0){
            throw new Exception("Depth should be greater than 0.");
        }

        this.depth = depth;
    }

    @Override
    public double getArea() {
        double area = 2 * this.getWidth() * this.getHeight() + 2 * this.getHeight() * this.getDepth() + 2 * this.getDepth() * this.getWidth();

        return area;
    }

    @Override
    public double getVolume() {
        double volume = this.getWidth() * this.getHeight() * this.getDepth();

        return volume;
    }

    @Override
    public String toString() {
        String result = "Cuboid:\n";
        result += String.format("Vertex: x=%.2f y=%.2f z=%.2f\n", this.getVertices().get(0)[0], this.getVertices().get(0)[1], this.getVertices().get(0)[2]);
        result += String.format("Width: %.2f\n", this.getWidth());
        result += String.format("Height: %.2f\n", this.getHeight());
        result += String.format("Depth: %.2f\n", this.getDepth());
        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Volume: %.2f\n", this.getVolume());

        return result;
    }
}