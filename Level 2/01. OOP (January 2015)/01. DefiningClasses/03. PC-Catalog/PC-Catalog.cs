using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PCCatalog
{
    class PcCatalog
    {
        public static void Main()
        {
            try
            {
                List<Computer> computers = new List<Computer>();

                Computer acer = new Computer(
                    name: "Acer Aspire",
                    processor: new Component("Processor" ,  350.36m, "Intel i7"),
                    ram: new Component("Ram", 105.25m, "8GB DDR3")
                );

                acer.AddComponents(new Component("Hdd", 200.00M));

                Computer toshiba = new Computer(
                    name: "Toshiba Satellite",
                    processor: new Component("Graphic card", 420.16m, "Ati Radeon R9 1GB"),
                    motherboard: new Component("Motherboard", 160.00m)
                );

                computers.Add(acer);
                computers.Add(toshiba);
                computers = computers.OrderBy(computer => computer.TotalPrice).ToList();

                foreach (Computer computer in computers)
                {
                    Console.WriteLine("*************************\n" + computer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
