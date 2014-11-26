import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class Exam22Jun14_04_StraightFlush {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		
		String[] line = input.nextLine().split("[, ]+");
		boolean isMatch = false;
		
		for (int c1 = 0; c1 < line.length; c1++) {
			for (int c2 = c1 + 1; c2 < line.length; c2++) {
				for (int c3 = c2 + 1; c3 < line.length; c3++) {
					for (int c4 = c3 + 1; c4 < line.length; c4++) {
						for (int c5 = c4 + 1; c5 < line.length; c5++) {
							
							ArrayList<Integer> faces = new ArrayList<Integer>();
							faces.add(face(line[c1]));
							faces.add(face(line[c2]));
							faces.add(face(line[c3]));
							faces.add(face(line[c4]));
							faces.add(face(line[c5]));
							Collections.sort(faces);
							
							String suit1 = suit(line[c1]);
							String suit2 = suit(line[c2]);
							String suit3 = suit(line[c3]);
							String suit4 = suit(line[c4]);
							String suit5 = suit(line[c5]);
							
							boolean checkSuits = suit1.equals(suit2) && suit2.equals(suit3) && suit3.equals(suit4) && suit4.equals(suit5);
							boolean checkFaces = (faces.get(0) + 1) == faces.get(1) && (faces.get(1) + 1) == faces.get(2) && (faces.get(2) + 1) == faces.get(3) && (faces.get(3) + 1) == faces.get(4);					
							
							if (checkSuits && checkFaces){
								System.out.printf("[%s, %s, %s, %s, %s]%n", card(faces.get(0), suit1), card(faces.get(1), suit1), card(faces.get(2), suit1), card(faces.get(3), suit1), card(faces.get(4), suit1));
								isMatch = true;
							}
						}
					}
				}
			}
		}
		
		if (!isMatch) {
			System.out.println("No Straight Flushes");
		}
	
	}
	
	
	public static int face (String card){
		int face = 0;
		String f = "";
		if (card.length() == 2) {
			f = "" + card.charAt(0);
		} else {
			f = "" + card.charAt(0) + card.charAt(1);
		}
		
		switch (f) {
			case "J":
				face = 11;
				break;
			case "Q":
				face = 12;
				break;
			case "K":
				face = 13;
				break;
			case "A":
				face = 14;
				break;
			
			default:
				face = Integer.parseInt(f);
				break;
		}
		
		return face;
	}
	
	public static String suit (String card){
		String s = "";
		
		if (card.length() == 2) {
			s = "" + card.charAt(1);
		} else {
			s = "" + card.charAt(2);
		}
			
		return s;
	}
	
	public static String card (int face, String suit){
		String card = "";
		
		switch (face) {
		case 11:
			card += "J";
			break;
		case 12:
			card += "Q";
			break;
		case 13:
			card += "K";
			break;
		case 14:
			card += "A";
			break;

		default:
			card += "" + face;
			break;
		}
		
		card += suit;
		
		return card;	
	}
}