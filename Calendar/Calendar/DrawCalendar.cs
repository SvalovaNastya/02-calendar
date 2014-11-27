using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    class DrawCalendar
    {
        static public void Draw(CalendarPage calendar)
        {
            var sizeScreen = Screen.PrimaryScreen.WorkingArea;
            Bitmap b = new Bitmap(sizeScreen.Width, sizeScreen.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
                Font drawFont = new Font("Arial", 16);
                var weigthInterval = sizeScreen.Height/(calendar.CalendarPageAsArray.GetLength(0) + 1);
                var heightInterval = sizeScreen.Width/(calendar.CalendarPageAsArray[0].Length);
                for (int i = 0; i < calendar.DaysOfWeekCount; i++)
                    g.DrawString(((DayOfWeek)((i + 1 + calendar.DaysOfWeekCount) % calendar.DaysOfWeekCount)).ToString(), drawFont, new SolidBrush(Color.Black),
                             i * heightInterval + heightInterval / 2, 0 + weigthInterval / 2, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.FillEllipse(new SolidBrush(Color.BlueViolet), new RectangleF(new PointF(calendar.Today.Item2 * heightInterval, calendar.Today.Item1 * weigthInterval), new SizeF(heightInterval, weigthInterval)));
                for (int i = 0; i < calendar.CalendarPageAsArray.GetLength(0); i++)
                    for (int j = 0; j < calendar.CalendarPageAsArray[i].Length; j++)
                        if (calendar.CalendarPageAsArray[i][j] != 0)
                            g.DrawString(calendar.CalendarPageAsArray[i][j].ToString(), drawFont, new SolidBrush(Color.Black), 
                                new PointF(j * heightInterval + heightInterval / 2, (i + 1) * weigthInterval + weigthInterval / 2), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
            }
            b.Save("1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }
    }
}
