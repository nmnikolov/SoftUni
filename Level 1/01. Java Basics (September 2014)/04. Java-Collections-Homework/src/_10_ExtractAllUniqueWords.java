import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		String[] sentence = input.nextLine().toLowerCase().split("[\\W]+");
		
		ArrayList<String> uniqueWords = new ArrayList<String>();
		
		for (String word : sentence) {
			if (!uniqueWords.contains(word)) {
				uniqueWords.add(word);
			}			
		}
		
		Collections.sort(uniqueWords);
		
		for (String word : uniqueWords) {
			System.out.print(word + " ");
		}	
	}
}