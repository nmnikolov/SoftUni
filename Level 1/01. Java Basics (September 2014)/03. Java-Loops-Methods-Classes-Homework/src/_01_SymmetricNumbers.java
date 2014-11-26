import java.util.Scanner;


public class _01_SymmetricNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		System.out.print("Enter start range: ");
		int start = input.nextInt();
		
		System.out.print("Enter end range: ");
		int end = input.nextInt();
		
		for (int i = start; i <= end; i++) {
			String number = new Integer(i).toString();		
			
			boolean check = true;
			for (int j = 0; j < number.length(); j++) {
				if (number.charAt(j) != number.charAt(number.length() - 1 - j)) {
					check = false;
				}
			}
			
			if (check) {
				System.out.print(i + " ");
			}
		}
	}	
}