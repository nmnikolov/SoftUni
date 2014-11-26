import java.util.Scanner;

public class Exam03Sep14_02_AddingAngles {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		String[] line = input.nextLine().split(" ");
		int[] angles = new int[n];
		boolean isMatch = false;
		
		for (int i = 0; i < n; i++) {
			angles[i] = Integer.parseInt(line[i]);
		}
		
		for (int a1 = 0; a1 < angles.length; a1++) {
			for (int a2 = a1 + 1; a2 < angles.length; a2++) {
				for (int a3 = a2 + 1; a3 < angles.length; a3++) {
					int sum = angles[a1] + angles[a2] + angles[a3];
					if (sum % 360 == 0) {
						System.out.printf("%d + %d + %d = %d degrees%n", angles[a1], angles[a2], angles[a3], sum);
						isMatch = true;
					}
				}
			}
		}
		
		if (!isMatch) {
			System.out.println("No");
		}
	}
}