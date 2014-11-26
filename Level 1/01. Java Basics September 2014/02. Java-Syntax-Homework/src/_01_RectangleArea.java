import java.util.*;


public class _01_RectangleArea {
	
	public static void main(String[] args) {
		
		Scanner input = new Scanner (System.in);
		
		System.out.print("Enter side a: ");
		int a = input.nextInt();
		System.out.print("Enter side b: ");
		int b = input.nextInt();
		
		int area = a * b;
		System.out.printf("Rectangle area: %d", area);
		
	}
	
}