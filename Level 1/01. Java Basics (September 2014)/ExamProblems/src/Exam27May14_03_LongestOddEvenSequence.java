import java.util.Scanner;


public class Exam27May14_03_LongestOddEvenSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		String[] enter = input.nextLine().replace('(', ' ').replace(')', ' ').split("[ ]+");
		int[] numbers = new int[enter.length - 1];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(enter[i + 1]);
		}
		
		int max = 0;
		int seq = 1;
		boolean even = numbers[0] % 2 == 0;
		
		for (int i = 1; i < numbers.length; i++) {
			if (even) {
				if (Math.abs(numbers[i] % 2) == 1 || numbers[i] == 0) {
					seq++;
					even = !even;		
				} else {
					max = Math.max(max,  seq);
					seq = 1;
					even = numbers[i] % 2 == 0;
				}
						
			} else {
				if (Math.abs(numbers[i] % 2) == 0 || numbers[i] == 0) {
					seq++;
					even = !even;
				} else {
					max = Math.max(max,  seq);
					seq = 1;
					even = numbers[i] % 2 == 0;
				}			
			}		
		}
		max = Math.max(max,  seq);
		
		System.out.println(max);
	}
}