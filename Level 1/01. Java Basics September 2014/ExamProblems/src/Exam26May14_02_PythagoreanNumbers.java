import java.util.Scanner;


public class Exam26May14_02_PythagoreanNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		int[] sides = new int[n];
		boolean isMatch = false;
		
		for (int i = 0; i < n; i++) {
			int side = Integer.parseInt(input.nextLine());
			sides[i] = side;
		}
		
		for (int s1 = 0; s1 < sides.length; s1++) {
			for (int s2 = s1; s2 < sides.length; s2++) {
				for (int s3 = s2; s3 < sides.length; s3++) {
					int min = Math.min(sides[s1], Math.min(sides[s2], sides[s3]));
					int max = Math.max(sides[s1], Math.max(sides[s2], sides[s3]));
					int middle = sides[s1] + sides[s2] + sides[s3] - min - max;
					
					if (min * min + middle * middle == max * max) {
						System.out.printf("%1$d*%1$d + %2$d*%2$d = %3$d*%3$d\n", min, middle, max);
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