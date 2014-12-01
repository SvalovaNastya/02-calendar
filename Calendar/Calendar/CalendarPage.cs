using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public enum Status
    {
        UsualDay,
        Weekend,
        CurrentDay,
        SpecialDay
    }

    public class Day
    {
        public readonly int Number;
        public Status Status;

        public Day(int number, Status status = Status.UsualDay)
        {
            Number = number;
            Status = status;
        }
    }

    public class CalendarPage
    {
        public Day[][] CalendarPageAsArray { get; private set; }
        public string[] DaysOfWeek;
        private DateTime firstDay;
        public readonly int DaysInMonth;
//        public Tuple<int, int> Today { get; private set; }

        public CalendarPage(int year, int month, DayOfWeek firstDayInWeek = DayOfWeek.Monday)
        {
            DaysOfWeek = MoveArray(Enum.GetValues(typeof (DayOfWeek)), (int) firstDayInWeek)
                .Select(x => x.ToString()).ToArray();
            DaysInMonth = DateTime.DaysInMonth(year, month);
            firstDay = new DateTime(year, month, 1);
            CalendarPageAsArray = GetCalendarPage();
            SetSpecialDay(27, Status.CurrentDay);
        }

        private object[] MoveArray(Array array, int offer)
        {
            var tempArray = new object[array.Length];
            offer = array.Length - offer;
            int count = 0;
            foreach (var element in array)
            {
                tempArray[(count + offer) % array.Length] = element;
                count++;
            }
            return tempArray;
        }

        private Day[][] GetCalendarPage()
        {
            var month = new List<List<Day>>();
            int countOfDaysInMonth = 0;
            while (countOfDaysInMonth < DaysInMonth)
                countOfDaysInMonth = FillingMonthArray(month, countOfDaysInMonth);
            return month.Select(x => x.ToArray()).ToArray();
        }

        private int FillingMonthArray(List<List<Day>> month, int countOfDaysInMonth)
        {
            month.Add(new List<Day>());
            for (int i = 0; i < DaysOfWeek.Length; i++)
                countOfDaysInMonth = AddOnlyDaysInThisMonth(month, countOfDaysInMonth, i);
            return countOfDaysInMonth;
        }

        private int AddOnlyDaysInThisMonth(List<List<Day>> month, int countOfDaysInMonth, int i)
        {
            if (IsDayInThisMonth(countOfDaysInMonth, i))
                month[month.Count - 1].Add(null);
            else
            {
                countOfDaysInMonth++;
                month[month.Count - 1].Add(new Day(countOfDaysInMonth));
            }
            return countOfDaysInMonth;
        }

        public void SetSpecialDay(int day, Status status)
        {
            for (int i = 0; i < CalendarPageAsArray.GetLength(0); i++)
                for (int j = 0; j < CalendarPageAsArray[i].Length; j++)
                    if (CalendarPageAsArray[i][j] != null && CalendarPageAsArray[i][j].Number == day)
                        CalendarPageAsArray[i][j].Status = status;
//            throw new IndexOutOfRangeException("День из неправильного диапозона");
        }

        private bool IsDayInThisMonth(int count, int i)
        {
            return (count == 0 && i < Array.IndexOf(DaysOfWeek, firstDay.DayOfWeek.ToString())) || count >= DaysInMonth;
        }
    }
}
