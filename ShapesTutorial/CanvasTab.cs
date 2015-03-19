using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PaintTutorial
{
    public class CanvasTab : TabPage
    {
        Canvas canvas = new Canvas();
        public CanvasTab(string text) : base(text)
        {
            Panel p = new Panel();
            p.AutoScroll = true;
            p.Controls.Add(canvas);
            this.Controls.Add(p);
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
            p.Dock = DockStyle.Fill;
        }
    }
}
