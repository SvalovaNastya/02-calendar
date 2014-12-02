using System;
using System.Linq;

namespace Calendar
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var inputLine = Console.ReadLine();
            if (inputLine == "")
                Console.WriteLine(
                    "Please, write data in format xx.xx.xxxx and optional parameter which day of week is first.");
            else
            {
                var arguments = inputLine.Split(' ').ToArray();
                var dataString = arguments[0].Split('.').Select(x => int.Parse(x)).ToArray();
                DayOfWeek firstDay = DayOfWeek.Monday;
                if (arguments.Length > 1)
                {
                    foreach (var el in Enum.GetValues(typeof (DayOfWeek)))
                    {
                        if (el.ToString() == arguments[1])
                            firstDay = (DayOfWeek)el;
                    }
                }
                CreateCalendar(dataString, firstDay);
            }
        }

        private static void CreateCalendar(int[] dataString, DayOfWeek firstDay)
        {
            var calendar = new CalendarPage(dataString[2], dataString[1], firstDay);
            try
            {
                calendar.SetSpecialDay(dataString[0], Status.CurrentDay);
                DrawCalendar.Draw(calendar);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
