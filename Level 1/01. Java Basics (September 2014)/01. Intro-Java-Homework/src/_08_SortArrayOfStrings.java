import java.util.*;

class _08_SortArrayOfStrings {
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("Number of towns to enter: ");		
		int n = Integer.parseInt(input.nextLine());
		String[] inputArray = new String[n];

		for (int i = 0; i < n; i++) {
			System.out.printf("Enter town %d: ", i + 1);
			inputArray[i] = input.nextLine();
		}

		Arrays.sort(inputArray);

		System.out.println("\nTowns sorted alphabetically :");
		for (String town : inputArray) {
			System.out.println(town);
		}
	}
	
}