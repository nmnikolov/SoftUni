import java.util.ArrayList;
import java.util.Scanner;

public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Character> listOfLetters1 = new ArrayList<Character>();
		ArrayList<Character> listOfLetters2 = new ArrayList<Character>();

		char[] firstLine = input.nextLine().toCharArray();

		for (char letter : firstLine) {
			if (Character.isLetter(letter)) {
				listOfLetters1.add(letter);
			}		
		}

		char[] secondLine = input.nextLine().toCharArray();

		for (char letter : secondLine) {
			if (!listOfLetters1.contains(letter) && Character.isLetter(letter)) {
				listOfLetters2.add(letter);
			}
		}

		listOfLetters1.addAll(listOfLetters2);

		for (char letter : listOfLetters1) {
			System.out.print(letter + " ");
		}	
	}
}