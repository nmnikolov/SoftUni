import java.util.Scanner;


public class _05_AngleUnitConverter {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("Number of queries for conversion: ");
		int n = input.nextInt();	
		
		for (int i = 0; i < n; i++) {
			
			double a = input.nextDouble();
			String s = input.next();
			
			if (s.equals("deg")) {
				a = a * Math.PI / 180;
				s = "rad";
			} else if (s.equals("rad")) {
				a = a * 180 / Math.PI;
				s = "deg";
			} else {
				System.out.println("Invalid input. Try again.");
				i--;
				continue;
			}
			
			System.out.printf("%.6f %s\n", a, s);
		}
	}	
}