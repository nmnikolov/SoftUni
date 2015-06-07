namespace InterestCalculator
{
    using System;

    public class InterestCalculatorTest
    {
        public static void Main()
        {
            InterestCalculator compound = new InterestCalculator(500, 5.6m, 10, InterestCalculator.GetCompooundInterest);
            Console.WriteLine(compound);

            InterestCalculator simple = new InterestCalculator(2500, 7.2m, 15, InterestCalculator.GetSimpleInterest);
            Console.WriteLine(simple);
        }
    }
}