import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class Exam01Jun14_04_LogsAggregator {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		int n = Integer.parseInt(input.nextLine());
		Map<String, TreeMap<String, Integer>> log = new TreeMap<String, TreeMap<String, Integer>>();
		
		for (int i = 0; i < n; i++) {
			String[] line = input.nextLine().split(" ");
			String name = line[1];
			String ip = line[0];
			int duration = Integer.parseInt(line[2]);
			
			
			if (log.containsKey(name)) {
				if (log.get(name).containsKey(ip)) {
					int count = log.get(name).get(ip).intValue();
					count += duration;
					log.get(name).put(ip, count);
					
				} else {
					log.get(name).put(ip, duration);
				}				
			} else {
				log.put(name, new TreeMap <String, Integer>());
				log.get(name).put(ip, duration);
			}
		}
		
		for (String name :  log.keySet()) {
			String ips = "[";
			int totalLoadTime = 0;;
			
			for (String ip : log.get(name).keySet()) {
				
				ips += ip + ", ";
				totalLoadTime += log.get(name).get(ip).intValue();
			}
			
			ips = ips.substring(0, ips.length() - 2) + "]";
			System.out.printf("%s: %d %s%n", name, totalLoadTime, ips);
		}	
	}
}