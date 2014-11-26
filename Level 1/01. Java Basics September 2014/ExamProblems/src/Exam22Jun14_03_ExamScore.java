import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


public class Exam22Jun14_03_ExamScore {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		input.nextLine();
		input.nextLine();
		input.nextLine();
		Map<Integer, TreeMap<String, Double>> scores = new TreeMap<Integer, TreeMap<String, Double>>();
		String lineInput = input.nextLine();

		
		while (!lineInput.startsWith("-")) {
			String[] line = lineInput.split("[|]+");
			String[] newLine = new String [line.length - 1];
			for (int i = 0; i < newLine.length; i++) {
				newLine[i] = line[i + 1].trim();
			}
			int score = Integer.parseInt(newLine[1]);
			double grade = Double.parseDouble(newLine[2]);
			
			if (scores.containsKey(score)) {
				scores.get(score).put(newLine[0], grade);
			} else {
				scores.put(score, new TreeMap<String, Double>());
				scores.get(score).put(newLine[0], grade);
			}			
			lineInput = input.nextLine();
		}
		
		
		for (Integer score :  scores.keySet()) {
			String names = "[";
			double totalGrade = 0;
			int count = 0;
			
			for (String name : scores.get(score).keySet()) {
				
				names += name + ", ";
				totalGrade += scores.get(score).get(name).doubleValue();
				count++;
			}
			
			names = names.substring(0, names.length() - 2) + "];";
			System.out.printf("%d -> %s avg=%.2f%n", score, names, (double)totalGrade / count);
		}	
	}
}