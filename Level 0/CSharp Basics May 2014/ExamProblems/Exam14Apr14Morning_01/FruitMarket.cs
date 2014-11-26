using System;

class FruitMarket
{
    static void Main()
    {
        string dayOfWeek = Console.ReadLine();
        decimal quantity1 = decimal.Parse(Console.ReadLine());
        string product1 = Console.ReadLine();
        decimal quantity2 = decimal.Parse(Console.ReadLine());
        string product2 = Console.ReadLine();
        decimal quantity3 = decimal.Parse(Console.ReadLine());
        string product3 = Console.ReadLine();

        decimal priceProduct1 = quantity1 * PriceList(product1) - quantity1 * PriceList(product1) * Discount(dayOfWeek, product1);
        decimal priceProduct2 = quantity2 * PriceList(product2) - quantity2 * PriceList(product2) * Discount(dayOfWeek, product2);
        decimal priceProduct3 = quantity3 * PriceList(product3) - quantity3 * PriceList(product3) * Discount(dayOfWeek, product3);
        decimal totalPrice = priceProduct1 + priceProduct2 + priceProduct3;
        Console.WriteLine("{0:F2}", totalPrice);
    }

    public static decimal PriceList(string product)
    {
        decimal price = 0;
        switch (product)
        {
            case "banana":
                price = 1.80M; break;
            case "cucumber":
                price = 2.75M; break;
            case "tomato":
                price = 3.20M; break;
            case "orange":
                price = 1.60M; break;
            case "apple":
                price = 0.86M; break;
        }
        return price;
    }

    public static decimal Discount (string dayOfWeek, string product)
    {
        decimal discount = 0M;
        switch (dayOfWeek)
        {
            case "Friday":
                discount = 10M / 100M; break;
            case "Sunday":
                discount = 5M / 100M; break;
            case "Tuesday":
                discount = 20M / 100M; break;
            case "Wednesday":
                discount = 10M / 100M; break;
            case "Thursday":
                discount = 30M / 100M; break;
        }
        switch (product)
        {
            case "banana":
                if (dayOfWeek == "Wednesday")
                {
                    discount = 0M;   
                }
                break;

            case "cucumber":       
            case "tomato":
                if (dayOfWeek == "Tuesday" || dayOfWeek == "Thursday")
                {
                    discount = 0M;   
                }
                break;

            case "orange":            
            case "apple":
                if (dayOfWeek == "Wednesday" || dayOfWeek == "Thursday")
                {
                    discount = 0M;   
                }
                break;
        }
        return discount;
    }
}