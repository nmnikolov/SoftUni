import java.util.ArrayList;
import java.util.Scanner;


public class Exam22Jun14_01_CognateWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String[] words = input.nextLine().split("[^a-zA-Z]+");
		ArrayList<String> uniqueWords = new ArrayList<String>();
		boolean isMatch = false;
		
		if (words.length < 3) {
			System.out.println("No");
			return;
		}
		
		for (int s1 = 0; s1 < words.length; s1++) {
			for (int s2 = 0; s2 < words.length; s2++) {
				for (int s3 = 0; s3 < words.length; s3++) {				
					String ab = words[s1] + words[s2];
					String c = words[s3];
			
					if (ab.equals(c)) {
						String output = words[s1] + "|" + words[s2] + "=" + ab;
						if (!uniqueWords.contains(output)) {
							uniqueWords.add(output);	
							isMatch = true;
						}									
					}
				}
			}
		}
		
		if (!isMatch) {
			System.out.println("No");
		} else {
			for (String word : uniqueWords) {
				System.out.println(word);
			}
		}
	}
}