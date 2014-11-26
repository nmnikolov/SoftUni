import java.text.DecimalFormat;
import java.util.Scanner;


public class Exam26May14_01_VideoDurations {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String line = input.nextLine();
		int totalMinutes = 0;
		
		while (!line.equals("End")) {
			String[] enter = line.split(":");
			totalMinutes += Integer.parseInt(enter[0]) * 60 + Integer.parseInt(enter[1]);
			line = input.nextLine();
		}
		
		System.out.printf("%d:%02d", totalMinutes / 60 , totalMinutes % 60);
	}
}