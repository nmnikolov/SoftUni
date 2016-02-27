namespace CombinationsWithRepetition
{
    using System;

    public class Combinations
    {
        private const int StartNumber = 1;
        private static int combinations = 0;

        public static void Main()
        {
            var userInput = ParseUserInput();

            int[] arr = new int[userInput.CombinationElements];
            GenCombs(arr, 0, StartNumber, userInput.TotalElements);

            Console.WriteLine("Combinations found: {0}", combinations);
        }

        private static void GenCombs(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                combinations++;
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    if (index > 0 && arr[index - 1] >= i)
                    {
                        continue;
                    }

                    arr[index] = i;
                    GenCombs(arr, index + 1, startNum, endNum);
                }
            }
        }

        private static UserInput ParseUserInput()
        {
            int totalElements,
                combinationElements;

            Console.Write("Enter total elements [e > 0]: ");
            bool parseEndNum = int.TryParse(Console.ReadLine(), out totalElements);
            while (!parseEndNum || totalElements < 1)
            {
                Console.Write("Invalid number. Enter total elemens: ");
                parseEndNum = int.TryParse(Console.ReadLine(), out totalElements);
            }

            Console.Write("Enter combination elements [c > 0, c <= e]: ");
            bool parseCombElements = int.TryParse(Console.ReadLine(), out combinationElements);

            while (!parseCombElements || combinationElements < 1 || combinationElements > totalElements)
            {
                Console.Write("Invalid number. Enter combination elements [c > 0, c <= e]: ");
                parseCombElements = int.TryParse(Console.ReadLine(), out combinationElements);
            }

            return new UserInput(totalElements, combinationElements);
        }
    }
}