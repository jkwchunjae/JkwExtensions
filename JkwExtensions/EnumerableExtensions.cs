﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkwExtensions
{
    public static class EnumerableExtensions
    {
        public static T GetRandom<T>(this IEnumerable<T> source, Func<T, double> getWeight = null)
        {
            getWeight = getWeight ?? (x => 1);

            var sum = source.Sum(getWeight);
            var rand = StaticRandom.Next(sum);

            foreach (var item in source)
            {
                rand -= getWeight(item);
                if (rand < 0)
                {
                    return item;
                }
            }

            return source.First();
        }

        public static IEnumerable<T> RandomShuffle<T>(this IEnumerable<T> source)
        {
            return source
                .Select(x => new { Index = StaticRandom.Next(999999999), T = x })
                .OrderBy(x => x.Index)
                .Select(x => x.T);
        }

        public static bool Empty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static bool Empty<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action, ICollection<(T Item, Exception Exception)> exceptions)
        {
            foreach (var item in source)
            {
                try
                {
                    action(item);
                }
                catch (Exception ex)
                {
                    exceptions?.Add((item, ex));
                }
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
        {
            foreach (var item in source)
            {
                await action(item);
            }
        }

        public static async Task ForEachParallelAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
        {
            var tasks = source
                .Select(async item => await action(item))
                .ToArray();

            await Task.WhenAll(tasks);
        }

        public static int? MaxOrNull<T>(this IEnumerable<T> source, Func<T, int> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Max(func);
            }
            else
            {
                return null;
            }
        }

        public static int? MaxOrNull(this IEnumerable<int> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Max();
            }
            else
            {
                return null;
            }
        }

        public static long? MaxOrNull<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Max(func);
            }
            else
            {
                return null;
            }
        }

        public static long? MaxOrNull(this IEnumerable<long> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Max();
            }
            else
            {
                return null;
            }
        }

        public static double? MaxOrNull<T>(this IEnumerable<T> source, Func<T, double> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Max(func);
            }
            else
            {
                return null;
            }
        }

        public static double? MaxOrNull(this IEnumerable<double> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Max();
            }
            else
            {
                return null;
            }
        }

        public static float? MaxOrNull<T>(this IEnumerable<T> source, Func<T, float> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Max(func);
            }
            else
            {
                return null;
            }
        }

        public static float? MaxOrNull(this IEnumerable<float> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Max();
            }
            else
            {
                return null;
            }
        }

        public static int? MinOrNull<T>(this IEnumerable<T> source, Func<T, int> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Min(func);
            }
            else
            {
                return null;
            }
        }

        public static int? MinOrNull(this IEnumerable<int> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Min();
            }
            else
            {
                return null;
            }
        }

        public static long? MinOrNull<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Min(func);
            }
            else
            {
                return null;
            }
        }

        public static long? MinOrNull(this IEnumerable<long> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Min();
            }
            else
            {
                return null;
            }
        }

        public static double? MinOrNull<T>(this IEnumerable<T> source, Func<T, double> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Min(func);
            }
            else
            {
                return null;
            }
        }

        public static double? MinOrNull(this IEnumerable<double> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Min();
            }
            else
            {
                return null;
            }
        }

        public static float? MinOrNull<T>(this IEnumerable<T> source, Func<T, float> func)
        {
            if (source?.Any() ?? false)
            {
                return source.Min(func);
            }
            else
            {
                return null;
            }
        }

        public static float? MinOrNull(this IEnumerable<float> source)
        {
            if (source?.Any() ?? false)
            {
                return source.Min();
            }
            else
            {
                return null;
            }
        }
    }
}
