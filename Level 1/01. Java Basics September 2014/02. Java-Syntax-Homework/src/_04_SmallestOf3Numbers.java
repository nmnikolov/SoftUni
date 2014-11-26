import java.util.Scanner;

public class _04_SmallestOf3Numbers {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);

		System.out.println("Enter 3 real numbers:");
		float a = input.nextFloat();
		float b = input.nextFloat();
		float c = input.nextFloat();
		
		float min = Math.min(a, Math.min(b, c));
		
		if (min % 1 == 0) {
			System.out.printf("Min number: %d", (int)min);			
		} else {
			System.out.printf("Min number: %.1f", min);
		}
	}
}