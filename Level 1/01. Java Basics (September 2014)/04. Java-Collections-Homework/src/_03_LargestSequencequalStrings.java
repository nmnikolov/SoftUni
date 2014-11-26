import java.util.Scanner;
import java.util.TreeMap;


public class _03_LargestSequencequalStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] elements = input.nextLine().split(" ");
		TreeMap<Integer, String> sequences = new TreeMap<Integer, String>();
		int maxSequence = 0;
		int sequence = 0;		
		
		for (int i = 0; i < elements.length; i++) {
			if (i < elements.length - 1 && elements[i].equals(elements[i + 1])) {
				sequence++;
			} else if (++sequence > maxSequence) {
				sequences.put(sequence, elements[i]);
				maxSequence = sequence;
				sequence = 0;
			} else {
				sequence = 0;
			}		
		}
		
		for (int i = 0; i < sequences.lastKey(); i++) {
			System.out.print(sequences.lastEntry().getValue() + " ");
		}		
	}
}