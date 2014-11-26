import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class Exam03Sep14_03_Biggest3PrimeNumbers {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		String[] enter = input.nextLine().replace('(', ' ').replace(')', ' ').split("[ ]+");
		ArrayList<Integer> primeNumbers = new ArrayList<Integer>(); 
		
		
		for (int i = 1; i < enter.length; i++) {
			int number = Integer.parseInt(enter[i]);
			if (isPrime(number) && !primeNumbers.contains(number)) {
				primeNumbers.add(number);
			}
		}
		
		Collections.sort(primeNumbers);
		
		if (primeNumbers.size() < 3) {
			System.out.println("No");
		} else {
			int sum = 0;
			for (int i = primeNumbers.size() - 1; i > primeNumbers.size() - 4; i--) {
				sum += primeNumbers.get(i);
			}
			
			System.out.println(sum);
		}	
	}
	
	public static boolean isPrime (int n){
		
		boolean prime = true;
		
		if (n < 2) {
			prime = false;
		}
		for (int i = 2; i <= Math.sqrt(n); i++) {
			if (n % i == 0) {
				prime = false;
			}
		}
		
		return prime;
	}
}