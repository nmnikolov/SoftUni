import java.util.ArrayList;
import java.util.Scanner;

public class Exam21Sep14_Morning_02_MagicSum {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);              
		int d = Integer.parseInt(input.nextLine());	   
		String line = input.nextLine();
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		boolean isMatch = false;
		int max = Integer.MIN_VALUE;
		String output = "";
		       
		while (!line.equals("End")) {
		    numbers.add(Integer.parseInt(line));                                   
		    line = input.nextLine();
		}
               
		for (int n1 = 0; n1 < numbers.size(); n1++) {
			for (int n2 = n1 + 1; n2 < numbers.size(); n2++) {
				for (int n3 = n2 + 1; n3 < numbers.size(); n3++) {
					int sum = numbers.get(n1) + numbers.get(n2) + numbers.get(n3);
					if (sum % d == 0) {
						if (sum > max) {
							max = sum;
							output = String.format("(%d + %d + %d) %% %d = 0", numbers.get(n1), numbers.get(n2), numbers.get(n3), d);
							isMatch = true;
						}                                                                                                  
					}
				}
			}                      
		}
       
        if (!isMatch) {
        	System.out.println("No");
        } else {
        	System.out.println(output);
        }
    }
}