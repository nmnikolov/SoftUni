import java.util.Scanner;


public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().toLowerCase().split("[\\W]+");
		String wordToFind = input.nextLine();
		int count = 0;

		for (String w : words) {
			if (w.equals(wordToFind)) {
				count++;
			}
		}
		
		System.out.println(count);
	}
}