using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintTutorial
{
    public class MyRectangle : Shape
    {

        public MyRectangle(string ID, Color Clr, int x, int y, int w, int h)
            : base(ID, Clr)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            origin = new Point(w / 2, h / 2);
        }
        /// <summary>
        /// Returns the Area of the Rectangle as a double. READ ONLY.
        /// </summary>
        public override double Area
        {
            get
            {
                return (double)(w * h);
            }
        }

        /// <summary>
        /// Draws the Rectangle using the Graphics object provided. **Needs to be called from the OnPaint() method of the parent class**
        /// </summary>
        /// <param name="g">The Graphics object used to draw the Rectangle.</param>
        public override void Draw(Graphics g)
        {
            SolidBrush myBrush = new SolidBrush(color);
            g.FillRectangle(myBrush, new Rectangle(x - origin.X, y - origin.Y, w, h));
            myBrush.Dispose();
        }
    }

    public class MyEllipse : Shape
    {
        public MyEllipse(string ID, Color Clr, int x, int y, int w, int h)
            : base(ID, Clr)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            origin = new Point(w / 2, h / 2);
        }

        /// <summary>
        /// Returns the Area of the Ellipse as a double. READ ONLY.
        /// </summary>
        public override double Area
        {
            get
            {
                return (double)(Math.PI * (w / 2) * (h / 2));
            }
        }

        /// <summary>
        /// Draws the Ellipse using the Graphics object provided. **Needs to be called from the OnPaint() method of the parent class**
        /// </summary>
        /// <param name="g">The Graphics object used to draw the Ellipse.</param>
        public override void Draw(Graphics g)
        {
            SolidBrush myBrush = new SolidBrush(color);
            g.FillEllipse(myBrush, new Rectangle(x - origin.X, y - origin.Y, w, h));
            myBrush.Dispose();
        }
    }
}
