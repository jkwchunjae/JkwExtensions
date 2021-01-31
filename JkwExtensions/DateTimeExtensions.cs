using System;
using System.Collections.Generic;
using System.Text;

namespace JkwExtensions
{
    public enum DateLanguage
    {
        KR, EN
    }

    public enum WeekdayFormat
    {
        /// <summary> 월, Mon </summary>
        D,
        /// <summary> 월요일, Monday </summary>
        DDD,
    }

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

        /// <summary> yyyymmdd hhmmss 형태의 str 을 DateTime으로 변환한다.  </summary>
        public static DateTime ToDateTime(this string str)
        {
            return new DateTime(
                str.Substring(0, 4).ToInt(),
                str.Substring(4, 2).ToInt(),
                str.Substring(6, 2).ToInt(),
                str.Substring(9, 2).ToInt(),
                str.Substring(11, 2).ToInt(),
                str.Substring(13, 2).ToInt());
        }

        public static DateTime? ToDate(this string dateStr)
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
                    return new DateTime(year, month, day);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string GetWeekday(this DateTime date, DateLanguage lang, WeekdayFormat format)
        {
            switch (lang)
            {
                case DateLanguage.KR:
                    var dayKr = "일월화수목금토".Substring(date.DayOfWeek.ToString("d").ToInt(), 1);
                    switch (format)
                    {
                        case WeekdayFormat.D:
                            return dayKr;
                        case WeekdayFormat.DDD:
                            return dayKr + "요일";
                    }
                    break;
                case DateLanguage.EN:
                    switch (format)
                    {
                        case WeekdayFormat.D:
                            return date.DayOfWeek.ToString("f").Substring(0, 3);
                        case WeekdayFormat.DDD:
                            return date.DayOfWeek.ToString("f");
                    }
                    break;
            }
            return string.Empty;
        }
    }
}
