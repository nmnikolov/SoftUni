import java.util.Arrays;
import java.util.Scanner;


public class _01_SortArray {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();
		int[] numbers = new int[n];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = input.nextInt();
		}
		
		Arrays.sort(numbers);
		
		for (int number : numbers) {
			System.out.printf(number + " ");
		}
	}
}