using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMain1
{
    interface StatisticsMC
    {
        void DumpOneResult(double result);
        double[,] GetResultsSoFar();
        StatisticsMC Close();
    }

    class StatisticsMean : StatisticsMC
    {
        public StatisticsMean()
        {
            running_sum_ = 0.0;
            paths_done_  = 0;
        }
        public StatisticsMean(StatisticsMean copied)
        {
            this.running_sum_ = copied.running_sum_;
            this.paths_done_ = copied.paths_done_;
        }
        public void DumpOneResult(double result)
        {
            paths_done_++;
            running_sum_ += result;
        }
        public double[,] GetResultsSoFar()
        {
            double[,] result = new double[1,1];
            result[0, 0] = running_sum_ / paths_done_;
            return result;
        }
        public StatisticsMC Close()
        {
            return new StatisticsMean(this);
        }

        private double running_sum_;
        private ulong paths_done_;
    }
}
