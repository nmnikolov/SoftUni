import java.util.Scanner;

public class _02_TriangleArea {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		System.out.println("Enter 3 point coordinates [x y]:");
		int a1 = input.nextInt();
		int a2 = input.nextInt();
		int b1 = input.nextInt();
		int b2 = input.nextInt();
		int c1 = input.nextInt();
		int c2 = input.nextInt();
		
		double area = (a1 * (b2 - c2) + b1 * (c2 - a2) + c1 * (a2 - b2))/2.0;
		
		System.out.printf("\nTriangle area: %d", Math.abs((int)area));
	}
	
}