using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Lab2
{
    class BigFactory : IHaveStrategy
    {
        public int Cost { get; set; }

        public int Income { get; set; }

        public int Loss { get; set; }

        public double GoodProbability { get; set; }

        public double BadProbability { get; set; }
        public int Years { get; set; }

        public double CalculateTotalIncome()
        {
            return (GoodProbability * Income + BadProbability * Loss) * Years - Cost;
        }
    }
}
