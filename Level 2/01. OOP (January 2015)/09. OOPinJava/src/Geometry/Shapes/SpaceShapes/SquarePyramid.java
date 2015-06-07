package Geometry.Shapes.SpaceShapes;

public class SquarePyramid extends SpaceShape{
    private double baseWidth;
    private double height;

    public SquarePyramid(double[] vertex, double baseWidth, double height) throws Exception{
        this.setVertices(vertex);
        this.setBaseWidth(baseWidth);
        this.setHeight(height);
    }

    public double getBaseWidth() {
        return this.baseWidth;
    }

    public void setBaseWidth(double baseWidth) throws Exception{
        if (baseWidth <= 0){
            throw new Exception("Base width should be greater than 0.");
        }

        this.baseWidth = baseWidth;
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
        double area = Math.pow(this.getBaseWidth(), 2) + 2 * this.getApotema() * this.getBaseWidth();

        return area;
    }

    @Override
    public double getVolume() {
        double volume = Math.pow(this.getBaseWidth(), 2) * this.getHeight() / 3;

        return volume;
    }

    private double getApotema(){
        double apotema = Math.sqrt(Math.pow(this.getHeight(), 2) + Math.pow(this.getBaseWidth() / 2, 2));

        return apotema;

    }

    @Override
    public String toString() {
        String result = "Square pyramid:\n";
        result += String.format("Vertex: x=%.2f y=%.2f z=%.2f\n", this.getVertices().get(0)[0], this.getVertices().get(0)[1], this.getVertices().get(0)[2]);
        result += String.format("Base width: %.2f\n", this.getBaseWidth());
        result += String.format("Height: %.2f\n", this.getHeight());
        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Volume: %.2f\n", this.getVolume());

        return result;
    }
}