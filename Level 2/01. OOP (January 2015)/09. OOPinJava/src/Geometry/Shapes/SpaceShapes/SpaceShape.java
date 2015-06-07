package Geometry.Shapes.SpaceShapes;

import Geometry.Interfaces.AreaMeasurable;
import Geometry.Shapes.Shape;
import Geometry.Interfaces.VolumeMeasurable;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {

    public abstract double getArea();

    public abstract double getVolume();
}
