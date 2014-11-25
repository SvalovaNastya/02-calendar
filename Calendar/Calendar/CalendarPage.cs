using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class CalendarPage
    {
        private DateTime firstDay;
        public int[][] CalendarPageAsArray { get; private set; }
        public readonly int DaysOfWeekCount;
        public readonly int DayOfWeekFirstDay;
        public readonly int DaysInMonth;
        public Tuple<int, int> Today { get; private set; }

        public CalendarPage(int year, int month)
        {
            firstDay = new DateTime(year, month, 1);
            DaysOfWeekCount = Enum.GetValues(typeof (DayOfWeek)).Length;
            DayOfWeekFirstDay = ((int)firstDay.DayOfWeek - 1 + DaysOfWeekCount) % DaysOfWeekCount;
            DaysInMonth = DateTime.DaysInMonth(firstDay.Year, firstDay.Month);
            CalendarPageAsArray = SetCalendarPage();
        }

        public Tuple<int, int> SetToday(int day)
        {
            if (day <= DaysInMonth && day > 0)
                for (int i = 0; i < CalendarPageAsArray.GetLength(0); i++)
                    for (int j = 0; j < CalendarPageAsArray[i].Length; j++)
                        if (CalendarPageAsArray[i][j] == day)
                            return Tuple.Create(i, j);
            throw new Exception("День из неправильного диапозона");
        }

        private int[][] SetCalendarPage()
        {
            var month = new List<List<int>>();
            int count = 0;
            while (count < DaysInMonth)
                count = FillingMonthArray(month, count);
            return month.Select(x => x.ToArray()).ToArray();
        }

        private int FillingMonthArray(List<List<int>> month, int count)
        {
            month.Add(new List<int>());
            for (int i = 0; i < DaysOfWeekCount; i++)
                count = AddOnlyCorrectDays(month, count, i);
            return count;
        }

        private int AddOnlyCorrectDays(List<List<int>> month, int count, int i)
        {
            if (IsDayInThisMonth(count, i))
                month[month.Count - 1].Add(0);
            else
            {
                count++;
                month[month.Count - 1].Add(count);
            }
            return count;
        }

        private bool IsDayInThisMonth(int count, int i)
        {
            return (count == 0 && i < DayOfWeekFirstDay) || count >= DaysInMonth;
        }
    }
}
