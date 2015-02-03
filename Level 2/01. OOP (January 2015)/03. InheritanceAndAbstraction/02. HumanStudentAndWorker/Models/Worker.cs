using System.Text;

namespace HumanStudentWorker.Models
{
    using System;
    using Interfaces;

    public class Worker : Human, INamable
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("weekSalary", "Salary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException("workHoursPerDay", "Work hours per day should be in the rande [0...24].");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary / (this.WorkHoursPerDay * 5);

            return moneyPerHour;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Work hours per day: {0}\n", this.WorkHoursPerDay);
            result.AppendFormat("Week salary: {0:N2}\n", this.WeekSalary);
            result.AppendFormat("Payment per hour: {0:N2}\n", this.MoneyPerHour());

            return result.ToString();
        }
    }
}