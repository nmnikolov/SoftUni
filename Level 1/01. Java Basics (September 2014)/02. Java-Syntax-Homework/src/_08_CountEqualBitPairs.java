import java.util.Scanner;

public class _08_CountEqualBitPairs {
	
	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		System.out.print("Enter integer number: ");
		int n = input.nextInt();
		String binary = Integer.toBinaryString(n);
		int count = 0;
		
		for (int i = 0; i < binary.length() - 1; i++) {
			if (binary.charAt(i) == binary.charAt(i + 1)) {
				count++;
			}
		}
		
		System.out.print("\nEqual bit pairs: " + count);
	}
}