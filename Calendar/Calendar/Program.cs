using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var dataString = Console.ReadLine().Split('.').Select(x => int.Parse(x)).ToArray();
            var calendar = new CalendarPage(dataString[2], dataString[1]);
            DrawCalendar.Draw(calendar);
        }
    }
}
