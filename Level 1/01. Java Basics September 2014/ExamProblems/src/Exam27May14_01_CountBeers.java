import java.util.Scanner;


public class Exam27May14_01_CountBeers {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		String line = input.nextLine();
		int totalBeers = 0;
		
		while (!line.equals("End")) {
			String[] enter = line.split(" ");
			int beers = Integer.parseInt(enter[0]);
			
			if (enter[1].endsWith("stacks")) {
				beers *=  20;
			}
			totalBeers += beers;
			line = input.nextLine();
		}
		
		System.out.printf("%d stacks + %d beers", totalBeers / 20 , totalBeers % 20);
	}
}