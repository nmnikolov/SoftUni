import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String sentence = input.nextLine().toLowerCase();
		String stringToSearch = input.nextLine();
		Pattern stringPattern = Pattern.compile(stringToSearch);
		Matcher matcher = stringPattern.matcher(sentence);
		int count = 0;
		
		while (matcher.find()) {
			count++;
			int firstIndex = matcher.start();
			matcher.region(firstIndex + 1, sentence.length());
		}
		
		System.out.println(count);
	}
}