import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;


public class Exam27May14_02_ThreeLargestNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		
		BigDecimal[] numbers = new BigDecimal[n]; 
		
		for (int i = 0; i < n; i++) {
			numbers[i] = new BigDecimal (input.nextLine());
		}
		
		Arrays.sort(numbers);
		
		if (n == 1) {
			System.out.println(numbers[0]);
		} else if (n == 2) {
			System.out.println(numbers[1] + "\n" + numbers[0]);
		} else {
			System.out.printf("%s%n%s%n%s", numbers[numbers.length - 1].toPlainString(), numbers[numbers.length - 2].toPlainString(), numbers[numbers.length - 3].toPlainString());
		}
	}
}