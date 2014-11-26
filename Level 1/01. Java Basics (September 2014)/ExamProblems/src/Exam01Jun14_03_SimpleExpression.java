import java.math.BigDecimal;
import java.util.Scanner;


public class Exam01Jun14_03_SimpleExpression {

	public static void main(String[] args) {
		Scanner input = new Scanner (System.in);
		
		String line = input.nextLine().replaceAll("[ ]", "");
		
		String[] signs = line.split("[\\d.]+");
		String[] n = line.split("[+-]");
		BigDecimal sum = new BigDecimal (Double.parseDouble(n[0])); 
		
		
		for (int i = 1; i < n.length; i++) {
			if (signs[i].equals("-")) {
				sum = sum.subtract(new BigDecimal (Double.parseDouble(n[i])));
			} else {
				sum = sum.add(new BigDecimal (Double.parseDouble(n[i])));
			}
		}
		
		System.out.println(sum);		
	}
}