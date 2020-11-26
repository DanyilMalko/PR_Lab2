using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Lab2
{
    class WaitOneYear : IHaveStrategy
    {
        public SmallFactory SmallFactory { get; set; }

        public BigFactory BigFactory { get; set; }

        public double PositiveProbability { get; set; }

        public double NegativeProbability { get; set; }

        public double CalculateTotalIncome()
        {
            double smallFactoryIncome = SmallFactory.CalculateTotalIncome();
            double bigFactoryIncome = BigFactory.CalculateTotalIncome();
            return Math.Max(smallFactoryIncome, bigFactoryIncome)* PositiveProbability;
        }
    }
}
