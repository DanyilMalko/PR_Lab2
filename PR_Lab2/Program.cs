using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PR_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategies = GetStrategies();
            var results = new double[3];
            int i = 0;
            foreach (var strategy in strategies)
            {
                results[i] = strategy.CalculateTotalIncome();
                Console.WriteLine("{2})Income with event '{0}' is {1}$", strategy.GetType().Name, results[i],i+1);
                i++;
            }
            var bestEvent = results.Max();
            Console.WriteLine("\nBest option is {0} with {1}$ income", Array.IndexOf(results,bestEvent) + 1, bestEvent );
        }

        private static  List<IHaveStrategy> GetStrategies()
        {
            var value = ReadNumberForTaskFromFile();

            var bigFactory = new BigFactory()
            {
                Cost = Convert.ToInt32(value[0]),
                Income = Convert.ToInt32(value[1]),
                GoodProbability= Convert.ToDouble(value[2]),
                Loss = Convert.ToInt32(value[3]),
                BadProbability = Convert.ToDouble(value[4]),
                Years = 5
            };

            var smallFactory = new SmallFactory()
            {
                Cost = Convert.ToInt32(value[5]),
                Income = Convert.ToInt32(value[6]),
                GoodProbability = Convert.ToDouble(value[7]),
                Loss = Convert.ToInt32(value[8]),
                BadProbability = Convert.ToDouble(value[9]),
                Years = 5
            };

            var waitOneYear = new WaitOneYear()
            {
                BigFactory = new BigFactory() {
                    Cost = Convert.ToInt32(value[0]),
                    Income = Convert.ToInt32(value[1]),
                    GoodProbability = Convert.ToDouble(value[12]),
                    Loss = Convert.ToInt32(value[3]),
                    BadProbability = Convert.ToDouble(value[13]),
                    Years = 4
                } ,
                SmallFactory = new SmallFactory()
                {
                    Cost = Convert.ToInt32(value[5]),
                    Income = Convert.ToInt32(value[6]),
                    GoodProbability = Convert.ToDouble(value[12]),
                    Loss = Convert.ToInt32(value[8]),
                    BadProbability = Convert.ToDouble(value[13]),
                    Years = 4
                },
                PositiveProbability = Convert.ToDouble(value[10]),
                NegativeProbability = Convert.ToDouble(value[11])
            };

            return new List<IHaveStrategy> { bigFactory, smallFactory, waitOneYear };
        }

        private static string[] ReadNumberForTaskFromFile()
        {
            var directory = String.Concat(System.IO.Directory.GetCurrentDirectory(), "\\inputValues.txt");
            var values = File
             .ReadLines(directory).FirstOrDefault().Split(" ").ToArray();

            return values;
        }
    }
}
