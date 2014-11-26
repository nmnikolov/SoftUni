import java.util.Scanner;


public class Exam01Jun14_01_StuckNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		int[] numbers = new int[n];
		
		for (int i = 0; i < n; i++) {
			numbers[i] = input.nextInt();
		}
		
		
		boolean isMatch = false;
		
		for (int d1 = 0; d1 < numbers.length; d1++) {
			for (int d2 = 0; d2 < numbers.length; d2++) {
				for (int d3 = 0; d3 < numbers.length; d3++) {
					for (int d4 = 0; d4 < numbers.length; d4++) {
						int a = numbers[d1];
						int b = numbers[d2];
						int c = numbers[d3];
						int d = numbers[d4];
						
						if (a != b && a != c && a != d && b != c && b != d && c != d) {
							String ab = "" + a + b;
							String cd = "" + c + d;
							
							if (ab.equals(cd)) {
								System.out.printf("%d|%d==%d|%d%n", a, b, c, d);
								isMatch = true;
							}			
						}
					}
				}
			}
		}
		
		if (!isMatch) {
			System.out.println("No");
		}		
	}
}