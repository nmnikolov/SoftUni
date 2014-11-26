import java.math.BigDecimal;
import java.util.Scanner;

public class Sample_01_SimpleCalculation {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		BigDecimal x = new BigDecimal (input.nextLine());
		BigDecimal y = new BigDecimal (input.nextLine());
		int result = 0;

		if (x.compareTo(BigDecimal.ZERO) == 0 && y.compareTo(BigDecimal.ZERO) == 0) {
			result = 0;
		} else if (x.compareTo(BigDecimal.ZERO) > 0 && y.compareTo(BigDecimal.ZERO) > 0) {
			result = 1;
		} else if (x.compareTo(BigDecimal.ZERO) < 0 && y.compareTo(BigDecimal.ZERO) > 0) {
			result = 2;
		} else if (x.compareTo(BigDecimal.ZERO) < 0 && y.compareTo(BigDecimal.ZERO) < 0) {
			result = 3;
		} else if (x.compareTo(BigDecimal.ZERO) > 0 && y.compareTo(BigDecimal.ZERO) < 0) {
			result = 4;
		} else if (x.compareTo(BigDecimal.ZERO) == 0 && y.compareTo(BigDecimal.ZERO) != 0) {
			result = 5;
		} else if (x.compareTo(BigDecimal.ZERO) != 0 && y.compareTo(BigDecimal.ZERO) == 0) {
			result = 6;
		}
		
		System.out.println(result);
	}
}