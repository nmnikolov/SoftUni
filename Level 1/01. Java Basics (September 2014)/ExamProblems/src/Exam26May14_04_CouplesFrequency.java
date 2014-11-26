import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;


public class Exam26May14_04_CouplesFrequency {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		String[] enter = input.nextLine().split(" ");
		String[] couples = new String [enter.length - 1];
		int tempCount = 0;
		
		for (int i = 0; i < couples.length; i++) {
			couples[i] = enter[i] + " " + enter[i + 1];
		}
		
		Map<String, Integer> frequencies = new LinkedHashMap<String, Integer>();
		
		for (String s : couples) {
			Integer count = frequencies.get(s);
			frequencies.put(s, (count == null) ? 1 : count + 1);
		}
		
		for (Map.Entry<String, Integer> couple : frequencies.entrySet()) {
			double frequency = (double)couple.getValue() / couples.length * 100;
			System.out.printf(couple.getKey() + " -> " + "%.2f%% \n", frequency);					
		}			
	}
}