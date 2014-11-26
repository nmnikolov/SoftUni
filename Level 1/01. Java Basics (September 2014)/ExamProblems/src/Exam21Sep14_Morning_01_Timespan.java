import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;

public class Exam21Sep14_Morning_01_Timespan {

	public static void main(String[] args) throws ParseException{
		Scanner input = new Scanner(System.in);	
		SimpleDateFormat format = new SimpleDateFormat("HH:mm:ss");
		Date endTime = format.parse(input.nextLine());
		Date startTime = format.parse(input.nextLine());
		
		long timeSpan = (endTime.getTime() - startTime.getTime()) / 1000;  // timeSpan in seconds
		
		long seconds = timeSpan % 60;
		long minutes = timeSpan / 60 % 60;
		long hours = timeSpan / (60 * 60);
		
		System.out.printf("%d:%02d:%02d", hours, minutes, seconds);
	}
}