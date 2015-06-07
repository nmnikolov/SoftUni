package Geometry.Shapes.PlaneShapes;

import Geometry.Interfaces.AreaMeasurable;
import Geometry.Interfaces.PerimeterMeasurable;
import Geometry.Shapes.Shape;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {

    public abstract double getArea();

    public abstract double getPerimeter();
}
