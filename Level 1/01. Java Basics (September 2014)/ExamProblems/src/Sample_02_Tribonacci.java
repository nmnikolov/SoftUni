import java.math.BigInteger;
import java.util.Scanner;


public class Sample_02_Tribonacci {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		BigInteger t1 = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		BigInteger t2 = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		BigInteger t3 = BigInteger.valueOf(Integer.parseInt(input.nextLine()));
		int a = Integer.parseInt(input.nextLine());
		
		BigInteger t = BigInteger.valueOf(a);
		
		
		if (a == 1) {
			System.out.println(t1);
		} else if (a == 2) {
			System.out.println(t2);
		} else {
			for (int i = 4; i <= a; i++) {
				t = t3.add(t2).add(t1);
				t1 = t2;
				t2 = t3;
				t3 = t;			
			}
			System.out.println(t3);
		}		
	}
}