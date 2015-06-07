namespace InterestCalculator
{
    using System;

    public delegate decimal CalculateInterest(decimal sum, decimal interest, int years);

    public class InterestCalculator
    {
        private const int N = 12;
        private const decimal InterestRate = 0.01M;
        private decimal sum;
        private decimal interest;
        private int years;

        public InterestCalculator(decimal sum, decimal interest, int years, CalculateInterest interestCalculation)
        {
            this.Sum = sum;
            this.Interest = interest;
            this.Years = years;
            this.InterestCalculation = interestCalculation;
        }

        public CalculateInterest InterestCalculation { get; set; }

        public decimal Sum 
        {
            get
            {
                return this.sum;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("sum", "Sum of money should be possitive.");
                }

                this.sum = value;
            } 
        }

        public decimal Interest
        {
            get
            {
                return this.interest;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interest", "Interest cannot be negative.");
                }

                this.interest = value;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("years", "Years should be possitive.");
                }

                this.years = value;
            }
        }

        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal simpleInterest = sum * (1 + (interest * InterestRate * years));

            return simpleInterest;
        }

        public static decimal GetCompooundInterest(decimal sum, decimal interest, int years)
        {
            decimal compoundInterest = sum * (decimal)Math.Pow(1 + ((double)interest * (double)InterestRate / N), years * N);

            return compoundInterest;
        }

        public override string ToString()
        {
            string result = string.Format("{0:F4}", this.InterestCalculation(this.Sum, this.Interest, this.Years));

            return result;
        }
    }
}