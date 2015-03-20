using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JamFactory.Helper {
    class Dates {
        public static int GetWeekNumberFromDate(DateTime time) {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        public static DateTime FirstDateOfWeek(int weekOfYear, int year) {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1 || firstWeek > 50) {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
        public static DateTime FirstDateOfWeek(int weekOfYear) {
            return FirstDateOfWeek(weekOfYear, 2015);
        }
        public static DateTime LastDateOfWeek(int weekOfYear) {
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTime jan1 = new DateTime(2015, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1 || firstWeek > 50) {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays((weekOfYear * 7) + 6);
        }
        public static string GetHoursFromDateTime(DateTime datetime) {
            return String.Format("{0:HH:mm}", datetime);
        }

        public static bool ValidWeekNumber(int weekOfYear, int year) {
            if (weekOfYear > 0) {
                DateTime dt = new DateTime(year, 12, 31);
                int week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                if (weekOfYear <= week)
                    return true;
            }

            return false;
        }
    }
}
