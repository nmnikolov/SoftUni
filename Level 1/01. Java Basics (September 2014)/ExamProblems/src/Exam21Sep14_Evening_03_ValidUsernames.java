import java.util.ArrayList;
import java.util.Scanner;


public class Exam21Sep14_Evening_03_ValidUsernames {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		
		String[] in = input.nextLine().split("[\\\\/() ]+");
		ArrayList<String> words = new ArrayList<String>();
		
		for (int i = 0; i < in.length; i++) {
			if (in[i].matches("\\b[a-zA-Z][a-zA-Z0-9_]{2,24}")) {
				words.add(in[i]);
			}
		}
		
		int maxLengthSum = 0;
		String longestWord1 = "";	
		String longestWord2 = "";
		
		for (int i = 0; i < words.size() - 1; i++) {
			int sum = words.get(i).length() + words.get(i + 1).length();
			
			if (sum > maxLengthSum) {
				longestWord1 = words.get(i);
				longestWord2 = words.get(i + 1);
				maxLengthSum = sum;
			}
		}
		
		System.out.println(longestWord1);
		System.out.println(longestWord2);
	}
}