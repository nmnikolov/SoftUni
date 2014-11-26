import java.util.Scanner;


public class Exam03Sep14_01_DozensOfEggs {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		int totalEggs = 0;
			
		for (int i = 0; i < 7; i++) {
			String[] line = input.nextLine().split(" "); 
			int eggs = Integer.parseInt(line[0]);
			if (line[1].equals("dozens")) {
				eggs *= 12;
			}
			
			totalEggs += eggs;
		}
		
		System.out.printf("%d dozens + %d eggs", totalEggs / 12, totalEggs % 12);
	}
}