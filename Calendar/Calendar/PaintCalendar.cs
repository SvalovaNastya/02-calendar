using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public class PaintCalendar : Form
    {
        private CalendarPage calendar;
        public PaintCalendar(CalendarPage calendar)
        {
            this.calendar = calendar;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < calendar.CalendarPageAsArray.GetLength(0); i++)
                for (int j = 0; j < calendar.CalendarPageAsArray[i].Length; j++)
                    e.Graphics.DrawString(calendar.CalendarPageAsArray[i][j].ToString(), DefaultFont, new SolidBrush(Color.Black), new PointF(j * 50+ 25, i * 50 + 25));
        }
    }
}
