import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Exam21Sep14_Evening_04_OfficeStuff {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());
		Map<String, LinkedHashMap<String, Integer>> stuff = new TreeMap<>();

		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().replaceAll("[|]", "").split("[\\- ]+");
			String company = line[0];
			int amount = Integer.parseInt(line[1]);
			String product = line[2];
			
			if (stuff.containsKey(company)) {
				if (stuff.get(company).containsKey(product)) {
					amount += stuff.get(company).get(product).intValue();
				}
			} else {
				stuff.put(company, new LinkedHashMap<String, Integer>());				
			}
			
			stuff.get(company).put(product, amount);
		}

		for (String company : stuff.keySet()) {
			String output = company + ":";

			for (String nut : stuff.get(company).keySet()) {
				output += String.format(" %s-%d,", nut, stuff.get(company).get(nut).intValue());
			}
			
			output = output.substring(0, output.length() - 1);
			System.out.println(output);
		}
	}
}