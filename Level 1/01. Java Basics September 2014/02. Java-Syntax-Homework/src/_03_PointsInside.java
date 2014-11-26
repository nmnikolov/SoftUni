import java.util.Scanner;

public class _03_PointsInside {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("Enter number of points to check: ");
		int n = input.nextInt();
				
		for (int i = 0; i < n; i++) {
			System.out.print("Enter point coodinates: ");
			float x = input.nextFloat();
			float y= input.nextFloat();
			
			boolean rect1 = x >= 12.5 && x <= 17.5 && y >= 8.5 && y <= 13.5 ? true : false;
			boolean rect2 = x >= 20 && x <= 22.5 && y >= 8.5 && y <= 13.5 ? true : false;
			boolean rect3 = x >= 12.5 && x <= 22.5 && y >= 6 && y <= 8.5 ? true : false;
			
			if (rect1 || rect2 || rect3) {
				System.out.println("Inside");
			} else {
				System.out.println("Outside");
			}						
		}
	}	
}