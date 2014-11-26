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
                var heightInterval = sizeScreen.Width/(calendar.CalendarPageAsArray[0].Length + 1);
                for (int i = 0; i < calendar.CalendarPageAsArray.GetLength(0); i++)
                    for (int j = 0; j < calendar.CalendarPageAsArray[i].Length; j++)
                        g.DrawString(calendar.CalendarPageAsArray[i][j].ToString(), drawFont, new SolidBrush(Color.Black), 
                            new PointF((j + 1) * heightInterval + heightInterval / 2, (i + 1) * weigthInterval + weigthInterval / 2));
            }
            b.Save("1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }
    }
}
