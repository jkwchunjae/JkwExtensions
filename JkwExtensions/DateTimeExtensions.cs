using System;
using System.Collections.Generic;
using System.Text;

namespace JkwExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// String to DateTime (yyyyMMdd, yyyy.MM.dd, yyyy-MM-dd)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool TryToDate(this string dateStr, out DateTime date)
        {
            int year = 0, month = 0, day = 0;
            var result = false;

            try
            {
                if (dateStr.Length == 8)
                {
                    year = dateStr.Substring(0, 4).ToInt();
                    month = dateStr.Substring(4, 2).ToInt();
                    day = dateStr.Substring(6, 2).ToInt();
                    result = true;
                }
                else if (dateStr.Length == 10)
                {
                    year = dateStr.Substring(0, 4).ToInt();
                    month = dateStr.Substring(5, 2).ToInt();
                    day = dateStr.Substring(8, 2).ToInt();
                    result = true;
                }

                if (result)
                {
                    date = new DateTime(year, month, day);
                }
                else
                {
                    date = DateTime.MinValue;
                }
            }
            catch
            {
                date = DateTime.MinValue;
                result = false;
            }

            return result;
        }
    }
}
