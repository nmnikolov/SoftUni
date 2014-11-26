import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class _12_CardsFrequencies {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] inputArray = input.nextLine().toUpperCase().split("[\\W]+");
		Map<String, Integer> cards = new LinkedHashMap<String, Integer>();
		int totalCards = inputArray.length;
		
		
		for (String card : inputArray) {
			Integer count = cards.get(card);
			cards.put(card, (count == null) ? 1 : count + 1);
		}
		
		for (Map.Entry<String, Integer>  w : cards.entrySet()) {
			double frequency = (double)w.getValue() / totalCards * 100;
			System.out.printf(w.getKey() + " -> " + "%.2f%% \n", frequency);					
		}			
	}
}