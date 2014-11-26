import java.util.ArrayList;
import java.util.Scanner;


public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] input = sc.nextLine().split(" ");
		int[] elements = new int[input.length];
		for (int i = 0; i < input.length; i++) {
			elements[i] = Integer.parseInt(input[i]);
		}	
		
		ArrayList<String> sequences = new ArrayList<String>();
		String currentSequence = "" + elements[0];
		int maxCount = 0;
		int count = 1;
		String longest = "";
	
		for (int i = 1; i < elements.length; i++) {
			if (elements[i] > (elements[i - 1])) {
				currentSequence += " " + elements[i];
				count++;
				if (i == elements.length - 1 && count > maxCount) {					
					longest = currentSequence;
				}
			}
			else {
				sequences.add(currentSequence.trim());
				if (count > maxCount) {
					maxCount = count;
					longest = currentSequence.trim();
				}				
				currentSequence = "" + elements[i];				
				count = 1;
			}
		}
		sequences.add(currentSequence.trim());	
		
		for (int i = 0; i < sequences.size(); i++) {
			System.out.println(sequences.get(i));
		}
		
		System.out.println("Longest: " + longest);
	}
}