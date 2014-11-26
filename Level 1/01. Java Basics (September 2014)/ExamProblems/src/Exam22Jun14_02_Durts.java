import java.util.Scanner;


public class Exam22Jun14_02_Durts {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int centreX = input.nextInt();
		int centreY = input.nextInt();
		int r = input.nextInt();
		int n = input.nextInt();
		input.nextLine();
		
		String[] line = input.nextLine().split("[ ]+");
		int[] coor = new int [2 * n];
		
		for (int i = 0; i < coor.length; i += 2) {
			coor[i] = Integer.parseInt(line[i]);
			coor[i + 1] = Integer.parseInt(line[i + 1]);
		}
		
		for (int i = 0; i < coor.length; i += 2) {
			boolean rect1 = true;
			boolean rect2 = true;
			if (coor[i] > centreX + r || coor[i] < centreX - r || coor[i + 1] > centreY + r / 2 || coor[i + 1] < centreY - r / 2 ) {
				rect1 = false;			
			}
			if (coor[i] > centreX + r /2  || coor[i] < centreX - r / 2 || coor[i + 1] > centreY + r || coor[i + 1] < centreY - r ) {
				rect2 = false;
			}
			if (rect1 || rect2) {
				System.out.println("yes");			
			} else {
				System.out.println("no");
			}		
		}	
	}
}