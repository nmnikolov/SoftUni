import java.util.Scanner;


public class _03_FullHouse {

	public static void main(String[] args) {
		
		String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
		char[] suits = { '\u2663', '\u2666', '\u2665', '\u2660' };
		int count = 0;
		
		for (int i = 0; i < faces.length; i++) {
			for (int j = 0; j < faces.length; j++) {	
				
				if (i == j) {
					continue;
				}
				
				for (int s1 = 0; s1 < suits.length; s1++) {
					for (int s2 = s1 + 1; s2 < suits.length; s2++) {
						for (int s3 = s2 + 1; s3 < suits.length; s3++) {
							for (int s4 = 0; s4 < suits.length; s4++) {
								for (int s5 = s4 + 1; s5 < suits.length; s5++) {
									
									System.out.printf("(%s%c %s%c %s%c %s%c %s%c) ", faces[i], suits[s1], faces[i], suits[s2],
											faces[i], suits[s3], faces[j], suits[s4], faces[j], suits[s5]);
									count++;
								}
							}
						}
					}
				}
			}
		}	
		
		System.out.printf("\n" + count + " full houses");
	}
}