using System;

class Budget
{
    static void Main()
    {
        int money = int.Parse(Console.ReadLine());
        int weekdays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());

        int hometownExpenses = (4 - hometown) * 40;
        int everydayExpenses = 22 * 10 + weekdays * (int)(3.0 / 100.0 * money);
        int totalAmmount = hometownExpenses + everydayExpenses + 150;

        if (totalAmmount == money)
        {
            Console.WriteLine("Exact Budget.");
        }
        else if (totalAmmount < money)
        {
            Console.WriteLine("Yes, leftover {0}.", money - totalAmmount);
        }
        else
        {
            Console.WriteLine("No, not enough {0}.", totalAmmount - money);
        }
    }
}
