import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class Exam27May14_04_Orders {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		int n = Integer.parseInt(input.nextLine());
		Map<String, TreeMap<String, Integer>> fruits = new LinkedHashMap<String, TreeMap<String, Integer>>();
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			
			if (fruits.containsKey(line[2])) {
				if (fruits.get(line[2]).containsKey(line[0])) {
					int count = fruits.get(line[2]).get(line[0]).intValue();
					count += Integer.parseInt(line[1]);
					fruits.get(line[2]).put(line[0], count);
					
				} else {
					fruits.get(line[2]).put(line[0], Integer.parseInt(line[1]));
				}
			} else {
				fruits.put(line[2], new TreeMap <String, Integer>());
				fruits.get(line[2]).put(line[0], Integer.parseInt(line[1]));
			}
		}
		
		for (String fruit :  fruits.keySet()) {
			String output = fruit + ": ";
			
			for (String name : fruits.get(fruit).keySet()) {
				output += name + " " + fruits.get(fruit).get(name).intValue() + ", ";
			}
			
			output = output.substring(0, output.length() - 2);
			System.out.println(output);
		}	
	}
}