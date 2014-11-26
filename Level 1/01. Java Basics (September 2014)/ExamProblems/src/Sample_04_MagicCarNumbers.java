import java.util.Scanner;


public class Sample_04_MagicCarNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int magicWeight = Integer.parseInt(input.nextLine());	
		char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X'};
		int count = 0;
	
		for (int d1 = 0; d1 <= 9; d1++) {
			for (int d2 = 0; d2 <= 9; d2++) {
				for (int d3 = 0; d3 <= 9; d3++) {
					for (int d4 = 0; d4 <= 9; d4++) {
						int weight = 40 + d1 +d2 +d3 + d4;
						
						if (magicWeight - weight < 20) {
							continue;
						}
						
						for (int l1 = 0; l1 < letters.length; l1++) {
							for (int l2 = 0; l2 < letters.length; l2++) {
								weight = 40 + d1 + d2 + d3 + d4 + (Character.getNumericValue(letters[l1]) - 9) * 10 + (Character.getNumericValue(letters[l2]) - 9) * 10;
								if (weight == magicWeight && checkDigits(d1, d2, d3, d4)) {
									count++;
								}
							}
						}
					}
				}
			}
		}
		
		System.out.println(count);		
	}
	
	public static boolean checkDigits (int d1, int d2, int d3, int d4){		
		boolean check = false;
		
		if (   (d1 == d2 && d2 == d3 && d3 == d4) 
			|| (d1 != d2 && d2 == d3 && d3 == d4)
			|| (d1 == d2 && d2 == d3 && d3 != d4)
			|| (d1 == d2 && d2 != d3 && d3 == d4)
			|| (d1 == d3 && d1 != d2 && d2 == d4)
			|| (d1 == d4 && d1 != d2 && d2 == d3)){
			check = true;
		}

		return check;
	}
}