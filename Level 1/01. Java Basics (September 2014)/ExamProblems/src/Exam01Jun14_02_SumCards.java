import java.util.Scanner;


public class Exam01Jun14_02_SumCards {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		
		int sum = 0;
		
		
		String[] line = input.nextLine().split("[ SCHD]+");
		int[] numbers = new int[line.length];
			
		for (int i = 0; i < numbers.length; i++) {
			int value = 0;
			switch (line[i]) {
			case "J":
				value = 12;
				break;
			case "Q":
				value = 13;
				break;
			case "K":
				value = 14;
				break;
			case "A":
				value = 15;
				break;
				
			default:
				value = Integer.parseInt(line[i]);
				break;
			}
			
			numbers[i] = value;
		}
		
		int tempSum = numbers[0];
		int count = 1;
		for (int i = 1; i < numbers.length; i++) {
			if (i == numbers.length - 1) {
				if (numbers[i] == numbers[i - 1]) {
					tempSum += numbers[i];
					sum += tempSum * 2;				
				} else if(count > 1) {
					sum += tempSum * 2 + numbers[i];	
				} else {
					sum += tempSum + numbers[i];
				}
			} else if (numbers[i] == numbers[i - 1]) {
				tempSum += numbers[i];
				count++;
			} else if (count > 1){
				sum += tempSum * 2;
				tempSum = numbers[i];
				count = 1;
			} else {
				sum += tempSum;
				tempSum = numbers[i];
				count = 1;
			}
		}
		
		if (numbers.length == 1) {
			sum = numbers[0];
		}
		
		System.out.println(sum);	
	}
}