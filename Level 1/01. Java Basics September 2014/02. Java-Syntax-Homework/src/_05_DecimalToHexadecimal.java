import java.util.Scanner;

public class _05_DecimalToHexadecimal {
	
	public static void main(String[] args) {
		System.out.print("Enter a positive integer number [0 <= n]: ");
		Scanner input = new Scanner(System.in);
		int number = input.nextInt();
		String hex = Integer.toHexString(number).toUpperCase();
		
		System.out.printf("\nHexadecimal: %s", hex);	
	}
}