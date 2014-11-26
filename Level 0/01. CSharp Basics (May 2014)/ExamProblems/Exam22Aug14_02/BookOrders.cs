using System;

class BookOrders
{
    static void Main()
    {
        int orders = int.Parse(Console.ReadLine());
        int totalBooks = 0;
        decimal totalValue = 0;

        for (int i = 0; i < orders; i++)
        {
            int packets = int.Parse(Console.ReadLine());
            int books = int.Parse(Console.ReadLine());
            decimal bookValue = decimal.Parse(Console.ReadLine());

            if (packets >= 10 && packets<= 109)
            {
                int discount = packets / 10 + 4;
                bookValue -= bookValue * discount / 100;
            }
            else if (packets >109)
            {
                bookValue -= bookValue * 15 / 100;
            }
            
            totalBooks += packets * books;
            totalValue += packets * books * bookValue;
        }

        Console.WriteLine(totalBooks);
        Console.WriteLine("{0:F2}", totalValue);
    }
}