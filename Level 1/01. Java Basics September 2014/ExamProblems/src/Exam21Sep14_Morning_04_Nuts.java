import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Exam21Sep14_Morning_04_Nuts {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		Map<String, LinkedHashMap<String, Integer>> nuts = new TreeMap<>();

		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			String company = line[0];
			String nut = line[1];
			int amount = Integer.parseInt(line[2].substring(0, line[2].length() - 2));

			if (nuts.containsKey(company)) {
				if (nuts.get(company).containsKey(nut)) {
					amount += nuts.get(company).get(nut).intValue();
				}
			} else {
				nuts.put(company, new LinkedHashMap<String, Integer>());				
			}
			
			nuts.get(company).put(nut, amount);
		}

		for (String company : nuts.keySet()) {
			String output = company + ":";

			for (String nut : nuts.get(company).keySet()) {
				output += String.format(" %s-%dkg,", nut, nuts.get(company).get(nut).intValue());
			}

			output = output.substring(0, output.length() - 1);
			System.out.println(output);
		}
	}
}