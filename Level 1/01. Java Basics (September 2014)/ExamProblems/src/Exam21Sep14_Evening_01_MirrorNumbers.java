import java.util.Scanner;


public class Exam21Sep14_Evening_01_MirrorNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);		
		int n = Integer.parseInt(input.nextLine());
		String[] numbers = input.nextLine().split(" "); 
		boolean isFound = false;
			
		for (int i = 0; i < numbers.length - 1; i++) {
			for (int j = i + 1; j < numbers.length; j++) {
				String reverse = new StringBuffer(numbers[j]).reverse().toString();
				
				if (numbers[i].equals(reverse)) {
					System.out.printf("%s<!>%s%n", numbers[i], numbers[j]);
					isFound = true;
				}				
			}
		}			
		
		if (!isFound) {
			System.out.println("No");
		}
	}
}