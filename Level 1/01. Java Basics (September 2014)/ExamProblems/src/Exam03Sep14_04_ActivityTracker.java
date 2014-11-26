import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class Exam03Sep14_04_ActivityTracker {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		int n = Integer.parseInt(input.nextLine());
		Map<Integer, TreeMap<String, Integer>> activity = new TreeMap<Integer, TreeMap<String, Integer>>();
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().replace('/', ' ').split(" ");
			int month = Integer.parseInt(line[1]);
			String name = line[3];
			int distance = Integer.parseInt(line[4]);
			
			
			if (activity.containsKey(month)) {
				if (activity.get(month).containsKey(name)) {
					int count = activity.get(month).get(name).intValue();
					count += distance;
					activity.get(month).put(name, count);
					
				} else {
					activity.get(month).put(name, distance);
				}
			} else {
				activity.put(month, new TreeMap <String, Integer>());
				activity.get(month).put(line[3], distance);
			}
		}
		
		for (Integer month :  activity.keySet()) {
			String output = month + ":";
			
			for (String name : activity.get(month).keySet()) {
				output += " " + name + "(" + activity.get(month).get(name).intValue() + "),";
			}
			
			output = output.substring(0, output.length() - 1);
			System.out.println(output);
		}	
	}
}