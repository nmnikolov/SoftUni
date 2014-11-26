import java.util.Scanner;


public class _06_FormattingNumbers {
	
	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter integer number a [0 <= a <= 500]: ");
		int a = input.nextInt();	
		System.out.print("Enter floating-point number b: ");
		float b = input.nextFloat();		
		System.out.print("Enter floating-point number c: ");
		float c = input.nextFloat();
		
		String hex = Integer.toHexString(a).toUpperCase();
		System.out.printf("|" + String.format("%-10s", hex) + "|");
		
		String binary = Integer.toBinaryString(a);
		System.out.printf(String.format("%10s", binary).replace(" ", "0") + "|");
		
		System.out.printf("%10.2f|", b);
		
		System.out.printf("%-10.3f|", c);
	}
}