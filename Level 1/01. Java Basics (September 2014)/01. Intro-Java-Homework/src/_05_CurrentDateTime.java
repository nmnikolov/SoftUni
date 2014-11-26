import java.text.SimpleDateFormat;
import java.util.Date;

class _05_CurrentDateTime {
	
	public static void main(String[] args) {	
		Date dNow = new Date();
		SimpleDateFormat dateF = new SimpleDateFormat("dd MMMM yyyy , H:mm:ss");
		System.out.println("Current date and time: " + dateF.format(dNow));	
	}
	
}