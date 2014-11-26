using System;

class TicTacToePower
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());

        int index = 3 * y + x + 1;
        long valueC = (long)Math.Pow(v + index - 1, index);
        Console.WriteLine(valueC);
    }
}