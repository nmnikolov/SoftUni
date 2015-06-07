namespace Customer
{
    using System;

    public class CustomerTest
    {
        public static void Main()
        {
            try
            {
                Customer stefan = new Customer("Stefan", "Ivanov", "Stefanov", "1234567890", "Sofia", "+359888777666", "proba@gmail.com", new Payment("VGA", 260.0m), CustomerType.Diamond);

                Customer copyOfStefan = stefan;

                Customer ivan = stefan.Clone() as Customer;
                ivan.FirstName = "Ivan";
                ivan.AddPayment(new Payment("CPU", 354.12m));
                
                Console.WriteLine(stefan);
                Console.WriteLine("Deep copy:\n{0}", ivan);
                Console.WriteLine("Equals (different customers): {0}", stefan.Equals(ivan));
                Console.WriteLine("Compare (different customers): {0}", stefan.CompareTo(ivan));
                Console.WriteLine("Equals (different customers, same reference): {0}", stefan.Equals(copyOfStefan));
                Console.WriteLine("Compare (different customers, same reference): {0}", stefan.CompareTo(copyOfStefan));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}