import java.util.Scanner;

public class _09_PointsInsideHouse {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("Enter number of points to check: ");
		int n = input.nextInt();
		
		for (int i = 0; i < n; i++) {
			System.out.print("Enter point coodinates: ");
			double pX = input.nextFloat();
			double pY= input.nextFloat();
			
			Point p = new Point(pX, pY); 
			Point t1 = new Point(12.5, 8.5);
			Point t2 = new Point(17.5, 3.5);
			Point t3 = new Point(22.5, 8.5);
			
			boolean rect1 = pX >= 12.5 && pX <= 17.5 && pY >= 8.5 && pY <= 13.5 ? true : false;
			boolean rect2 = pX >= 20 && pX <= 22.5 && pY >= 8.5 && pY <= 13.5 ? true : false;
			
			if (pointInTriangle(p, t1, t2, t3) || rect1 || rect2) {
				System.out.println("Inside");
			} else {
				System.out.println("Outside");
			}			
		}
	}
	
	public static double sign(Point p1, Point p2, Point p3)
	{
	  return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y);
	}

	public static boolean pointInTriangle(Point pt, Point v1, Point v2, Point v3)
	{
	  boolean b1, b2, b3;

	  b1 = sign(pt, v1, v2) < 0.0f;
	  b2 = sign(pt, v2, v3) < 0.0f;
	  b3 = sign(pt, v3, v1) < 0.0f;

	  return ((b1 == b2) && (b2 == b3));
	}
}

class Point {
	public double x, y;

	public Point(double x, double y) {
		this.x = x;
		this.y = y;
	}

	public double getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	public void setY(double y) {
		this.y = y;
	}
}