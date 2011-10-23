using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMain1
{
    class SimpleMC7
    {
        public static void SimpleMonteCarlo4(VanillaOption option,
                                double spot,
                                Parameters vol,
                                Parameters r,
                                ulong number_of_paths,
                                StatisticsMC gatherer)
        {
            double expiry = option.Expiry;
            double variance = vol.IntegralSquare(0, expiry);
            double root_variance = Math.Sqrt(variance);
            double moved_spot = spot * Math.Exp(r.Integral(0, expiry) - 0.5 * variance);

            double this_spot;
            double discounting = Math.Exp(-r.Integral(0, expiry));
            for (ulong i = 0; i < number_of_paths; i++)
            {
                double this_gaussian = MyRandom.GetOneGaussianByBoxMuller();
                this_spot = moved_spot * Math.Exp(root_variance * this_gaussian);
                gatherer.DumpOneResult(discounting * option.OptionPayOff(this_spot));
            }
        }
    }
}
