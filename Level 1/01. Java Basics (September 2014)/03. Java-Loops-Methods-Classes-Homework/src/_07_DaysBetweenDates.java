import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;


public class _07_DaysBetweenDates {

	public static void main(String[] args) throws ParseException {
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter start date: ");
		String start = input.nextLine();		
		System.out.print("Enter end date: ");
		String end = input.nextLine();
		
		SimpleDateFormat formatter = new SimpleDateFormat("dd-MM-yyyy");
		Date startDate = formatter.parse(start);
		Date endDate = formatter.parse(end);
		
		long diff = endDate.getTime() - startDate.getTime();
	    System.out.println ("Days: " + TimeUnit.DAYS.convert(diff, TimeUnit.MILLISECONDS));	
	}
}