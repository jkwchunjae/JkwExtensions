using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JkwExtensions
{
    public static class MathHelper
    {
        public static double StandardDeviation(this IEnumerable<double> source)
        {
            if (source.Any())
                return 0;

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Sum(val => (val - average) * (val - average));
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Count());

            return sd;
        }
    }
}
