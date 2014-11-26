import java.util.Scanner;

public class _07_CountBitsOne {
	
	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		System.out.print("Enter integer number: ");
		int n = input.nextInt();	
		
		System.out.println("\nCount of bit \"1\": "  + Integer.bitCount(n));
	}
}