import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _08_ExtractEmails {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern emailPattern = Pattern.compile("([a-zA-Z0-9]+[._-]*)+[@]([a-zA-Z0-9-]+[.]+)+([a-zA-Z0-9])+");
		Matcher matcher = emailPattern.matcher(text);
		while (matcher.find()) {
			System.out.println(matcher.group());
		}			
	}
}