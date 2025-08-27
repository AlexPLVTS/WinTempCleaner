using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTempCleaner.Utils
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle fullRect = this.ClientRectangle;

            SolidBrush backColorBrush = new SolidBrush(this.BackColor);
            SolidBrush foreColorBrush = new SolidBrush(this.ForeColor);

            Rectangle barRect = new Rectangle(0, 0, fullRect.Width, fullRect.Height);
            barRect.Width = (int)(fullRect.Width * ((double)Value / Maximum));

            e.Graphics.FillRectangle(backColorBrush, fullRect);

            if (barRect.Width > 0)
            {
                e.Graphics.FillRectangle(foreColorBrush, barRect);
            }

            backColorBrush.Dispose();
            foreColorBrush.Dispose();
        }
    }
}
