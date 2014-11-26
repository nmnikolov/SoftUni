import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class Exam21Sep14_Evening_02_PossibleTriangles {

	public static void main(String[] args) {
		
		Scanner input = new Scanner (System.in);
		String line = input.nextLine();
		boolean isFound = false;
			
		while (!line.equals("End")) {
					
			String[] in = line.split(" ");		
			ArrayList<Double> numbers = new ArrayList<Double>();
			
			for (int i = 0; i < 3; i++) {
				numbers.add(Double.parseDouble(in[i]));
			}
			
			Collections.sort(numbers);
			
			if (numbers.get(0) + numbers.get(1) > numbers.get(2)) {
				System.out.printf("%.2f+%.2f>%.2f%n", numbers.get(0), numbers.get(1), numbers.get(2));
				isFound = true;
			}
			
			line = input.nextLine();
		}
				
		if (!isFound) {
			System.out.println("No");
		} 
	}
}