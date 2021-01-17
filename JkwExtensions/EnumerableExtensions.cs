using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkwExtensions
{
    public static class EnumerableExtensions
    {
        #region Random

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

        #endregion

        #region Empty

        public static bool Empty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static bool Empty<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        #endregion

        #region ForEach

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

        #endregion

        #region When *

        public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> source)
        {
            return await Task.WhenAll(source);
        }

        public static async Task WhenAll<T>(this IEnumerable<Task> source)
        {
            await Task.WhenAll(source);
        }

        public static async Task<Task<T>> WhenAny<T>(this IEnumerable<Task<T>> source)
        {
            return await Task.WhenAny(source);
        }

        public static async Task<Task> WhenAny<T>(this IEnumerable<Task> source)
        {
            return await Task.WhenAny(source);
        }

        #endregion

        #region MaxOrNull, MinOrNull

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

        #endregion

        #region Reduce

        public static TResult Reduce<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, TResult> fn)
        {
            return Reduce(source, initValue, (value, item, index, list) => fn(value, item));
        }

        public static TResult Reduce<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, int, TResult> fn)
        {
            return Reduce(source, initValue, (value, item, index, list) => fn(value, item, index));
        }

        public static TResult Reduce<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, int, IEnumerable<TSource>, TResult> fn)
        {
            var value = initValue;

            var index = 0;
            foreach (var item in source)
            {
                value = fn(value, item, index++, source);
            }

            return value;
        }

        public static Task<TResult> ReduceAsync<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, Task<TResult>> fn)
        {
            return ReduceAsync(source, initValue, (value, item, index, list) => fn(value, item));
        }

        public static Task<TResult> ReduceAsync<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, int, Task<TResult>> fn)
        {
            return ReduceAsync(source, initValue, (value, item, index, list) => fn(value, item, index));
        }

        public static async Task<TResult> ReduceAsync<TSource, TResult>(this IEnumerable<TSource> source, TResult initValue, Func<TResult, TSource, int, IEnumerable<TSource>, Task<TResult>> fn)
        {
            var value = initValue;

            var index = 0;
            foreach (var item in source)
            {
                value = await fn(value, item, index++, source);
            }

            return value;
        }

        #endregion
    }
}
