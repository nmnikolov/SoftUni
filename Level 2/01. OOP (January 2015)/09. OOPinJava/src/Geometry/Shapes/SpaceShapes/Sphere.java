package Geometry.Shapes.SpaceShapes;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(double[] vertex, double radius) throws Exception{
        this.setVertices(vertex);
        this.setRadius(radius);
    }

    public double getRadius(){
        return this.radius;
    }

    public void setRadius(double radius) throws Exception{
        if (radius <= 0){
            throw new Exception("Radius should be greater than 0.");
        }

        this.radius = radius;
    }

    @Override
    public double getArea() {
        double area = 4 * Math.PI * Math.pow(this.getRadius(), 2);

        return area;
    }

    @Override
    public double getVolume() {
        double volume = 4 * Math.PI * Math.pow(this.getRadius(), 3) / 3;

        return volume;
    }

    @Override
    public String toString() {
        String result = "Sphere:\n";
        result += String.format("Vertex: x=%.2f y=%.2f z=%.2f\n", this.getVertices().get(0)[0], this.getVertices().get(0)[1], this.getVertices().get(0)[2]);
        result += String.format("Radius: %.2f\n", this.getRadius());
        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Volume: %.2f\n", this.getVolume());

        return result;
    }
}
