import java.util.Arrays;
import java.util.Collections;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class _11_MostFrequentWord {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		String[] sentence = input.nextLine().toLowerCase().split("[\\W]+");		
		Map<String, Integer> words = new TreeMap<String, Integer>();	
		Arrays.sort(sentence);
		int count = 1;
			
		for (int i = 1; i < sentence.length; i++) {
			if (sentence[i].equals(sentence[i - 1])) {
				count++;
				if (i == sentence.length - 1) {
					words.put(sentence[i], count);
				}
			} else {
				words.put(sentence[i - 1], count);
				count = 1;
			}			
		}
		
		int maxRepeated = (Collections.max(words.values()));
		
		for (Map.Entry<String, Integer>  word : words.entrySet()) {
			if (word.getValue() == maxRepeated) {
				System.out.println(word.getKey() + " -> " + word.getValue() + " times");
			}			
		}	
	}
}