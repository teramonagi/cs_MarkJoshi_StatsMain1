using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMain1
{
    class Program
    {
        static void Main(string[] args)
        {
            //parameters
            double expiry = 1.0;
            double strike = 50.0;
            double spot = 49.0;

            ParametersConstant vol = new ParametersConstant(0.2);
            ParametersConstant r   = new ParametersConstant(0.01);

            //input number of montecarlo paths
            ulong number_of_paths = 10000;

            //create payoff & option object
            PayOff payoff = new PayOffCall(strike);
            //implicit convert
            VanillaOption option1 = new VanillaOption(payoff, expiry);
            
            //montecarlo simulation & output result
            StatisticsMC gatherer = new StatisticsMean();
            SimpleMC7.SimpleMonteCarlo4(option1, spot, vol, r, number_of_paths, gatherer);
            double[,] result = gatherer.GetResultsSoFar();
            Console.WriteLine("For the call price, the results are ");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.WriteLine(result[i, j]);
                }
            }
        }
    }
}
