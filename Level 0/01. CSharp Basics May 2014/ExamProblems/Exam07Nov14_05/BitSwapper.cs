using System;
using System.Linq;
using System.Collections;

class BitSwapper
{
    static void Main()
    {
        uint[] numbers = new uint[4];

        for (int i = 0; i < 4; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        string input = Console.ReadLine();

        while (input != "End")
        {
            int[] pair1 = input.Split(' ').Select(int.Parse).ToArray();
            input = Console.ReadLine();
            int[] pair2 = input.Split(' ').Select(int.Parse).ToArray();

            uint mask1 = (numbers[pair1[0]] >> pair1[1] * 4) & 15;
            uint mask2 = (numbers[pair2[0]] >> pair2[1] * 4) & 15;

            numbers[pair1[0]] &= (~((uint)15 << pair1[1] * 4));
            numbers[pair1[0]] |= (mask2 << pair1[1] * 4);

            numbers[pair2[0]] &= (~((uint)15 << pair2[1] * 4));
            numbers[pair2[0]] |= (mask1 << pair2[1] * 4);

            input = Console.ReadLine();
        }

        foreach (ulong number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}