using System;

namespace JkwExtensions
{
    public static class StaticRandom
    {
        public static Random random = new Random((int)DateTime.Now.Ticks);

        public static double Next()
        {
            return random.NextDouble();
        }

        public static double Next(double maxValue)
        {
            return random.NextDouble() * maxValue;
        }

        public static double Next(double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
    }


}
