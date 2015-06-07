package Geometry.Shapes.PlaneShapes;

public class Triangle extends PlaneShape {

    public Triangle(double[] firstVertice, double[] secondVertice, double[] thirdVertice) throws Exception{
        this.setVertices(firstVertice);
        this.setVertices(secondVertice);
        this.setVertices(thirdVertice);
    }

    @Override
    public double getArea() {
        double aX = this.getVertices().get(0)[0];
        double aY = this.getVertices().get(0)[1];
        double bX = this.getVertices().get(1)[0];
        double bY = this.getVertices().get(1)[1];
        double cX = this.getVertices().get(2)[0];
        double cY = this.getVertices().get(2)[1];
        double area = Math.abs((aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);

        return area;
    }

    @Override
    public double getPerimeter() {
        double sideA = distanceBetweenTwoPoints(this.vertices.get(0), this.vertices.get(1));
        double sideB = distanceBetweenTwoPoints(this.vertices.get(1), this.vertices.get(2));
        double sideC = distanceBetweenTwoPoints(this.vertices.get(2), this.vertices.get(0));
        double perimeter = sideA + sideB + sideC;

        return perimeter;
    }

    @Override
    public String toString() {

        String result = "Triangle:\n";

        for (int i = 0; i < this.getVertices().size(); i++) {
            result += String.format("Point%d: x=%.2f y=%.2f\n", i + 1, this.getVertices().get(i)[0], this.getVertices().get(i)[1]);
        }

        result += String.format("Area: %.2f\n", this.getArea());
        result += String.format("Perimeter: %.2f\n", this.getPerimeter());

        return result;
    }

    private double distanceBetweenTwoPoints(double[] firstVertice, double[] secondVertice){

        double distance = Math.sqrt(Math.pow(firstVertice[0] - secondVertice[0], 2) + Math.pow(firstVertice[1] - secondVertice[1], 2));

        return distance;
    }
}