import java.util.Scanner;


public class _02_Generate3LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String letters = input.nextLine();
		
		for (int i = 0; i < letters.length(); i++) {
			for (int j = 0; j < letters.length(); j++) {
				for (int t = 0; t < letters.length(); t++) {
					System.out.printf("" + letters.charAt(i) + letters.charAt(j) + letters.charAt(t) + " ");
				}
			}
		}	
	}
}