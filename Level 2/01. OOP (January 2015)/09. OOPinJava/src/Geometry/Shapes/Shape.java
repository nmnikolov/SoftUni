package Geometry.Shapes;

import Geometry.Shapes.PlaneShapes.PlaneShape;
import Geometry.Shapes.SpaceShapes.SpaceShape;

import java.util.ArrayList;
import java.util.List;

public abstract class Shape {
    protected ArrayList<double[]> vertices;

    protected List<double[]> getVertices(){
        return this.vertices;
    }

    protected void setVertices(double[] vertice) throws Exception{
        if (this instanceof PlaneShape && vertice.length != 2){
            throw new Exception("Vertice should contain only X and Y.");
        }

        if (this instanceof SpaceShape && vertice.length != 3){
            throw new Exception("Vertice should contain only X, Y and Z.");
        }

        if (this.vertices == null){
            this.vertices = new ArrayList<double[]>();
        }

        this.vertices.add(vertice);
    }
}