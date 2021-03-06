﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JkwExtensions
{
    public static class ConsoleHelper
    {
        public static void ConsoleWriteLine(this object obj)
        {
            Console.WriteLine(obj);
        }

        public static string ReadInput(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }

        public static string Dump(this string value, string title = "")
        {
            if (title == "")
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine(title + ": " + value);
            }
            return value;
        }

        public static IEnumerable<string> Dump(this IEnumerable<string> strList, string title = "")
        {
            title.Dump();
            foreach (var tuple in strList.Select((x, i) => Tuple.Create(x, i)))
                "[{1}] {0}".With(tuple.Item1, tuple.Item2).Dump();
            return strList;
        }

        public static IEnumerable<T> Dump<T>(this IEnumerable<T> objList, string title = null)
        {
            if (title == null)
            {
                typeof(T).Name.Dump();
            }
            else
            {
                title.Dump();
            }

            objList
                .Select((x, i) => new { Index = i, Text = x.ToString() })
                .ForEach(x => $"[{x.Index}] {x.Text}".Dump());

            return objList;
        }
    }
}
