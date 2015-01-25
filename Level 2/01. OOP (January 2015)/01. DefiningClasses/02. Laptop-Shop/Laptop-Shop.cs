using System;

namespace _02.LaptopShop
{
    class LaptopShop
    {
        public static void Main()
        {
            try
            {
                Laptop acer = new Laptop(model: "Acer", price: 13.5m, hdd: 500, batteryType: "Li-On");
                Console.WriteLine(acer);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }          
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}