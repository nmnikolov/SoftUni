import java.util.Scanner;

public class Exam21Sep14_Morning_03_WeirdStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String line = input.nextLine().replaceAll("[\\/()| ]+", "");
		String[] words = line.split("[^a-zA-Z]+");
		int[] weights = new int[words.length];

		int max = Integer.MIN_VALUE;
		String max1Word = "";
		String max2Word = "";

		for (int i = 0; i < words.length; i++) {
			weights[i] = getWeight(words[i]);
		}

		for (int i = 0; i < weights.length - 1; i++) {
			int weight = weights[i] + weights[i + 1];
			if (weight >= max) {
				max1Word = words[i];
				max2Word = words[i + 1];
				max = weight;
			}
		}

		System.out.println(max1Word);
		System.out.println(max2Word);
	}

	public static int getWeight(String word) {
		int weight = 0;
		word = word.toLowerCase();

		for (int i = 0; i < word.length(); i++) {
			weight += Character.getNumericValue(word.charAt(i)) - 9;
		}

		return weight;
	}
}