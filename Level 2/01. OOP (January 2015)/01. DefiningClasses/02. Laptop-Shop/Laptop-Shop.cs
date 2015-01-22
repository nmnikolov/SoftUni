using System;

namespace _02.LaptopShop
{
    class LaptopShop
    {
        public static void Main()
        {
            try
            {
                Laptop acer = new Laptop(model: "Acer", price: 13.5m, batteryType: "Li-On", batteryLife: 0.1d);
                Console.WriteLine(acer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}