import java.util.Arrays;
import java.util.Scanner;


public class _02_SequencesEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] elements = input.nextLine().split(" ");
		
		for (int i = 0; i < elements.length; i++) {
			if(i == 0){
				System.out.print(elements[i]);
				continue;
			}
			
			if (elements[i].equals(elements[i - 1])) {
				System.out.print(" " + elements[i]);
			} else {
				System.out.print("\n" + elements[i]);
			}
			
		}
	}
}