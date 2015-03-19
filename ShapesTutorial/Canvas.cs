using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintTutorial
{
    public partial class Canvas : UserControl
    {
        private List<Shape> shapes = new List<Shape>();
        private Point oldMouseLocation = new Point(0, 0);
        bool mouseDown = false;

        public Canvas()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
        }

        private void ShapeDrawer_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentDrawMode == DrawMode.Shapes)
            {
                DrawShape(e);
            }
        }

        private void DrawShape(MouseEventArgs e)
        {
            Shape s = null;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                s = new MyRectangle(shapes.Count.ToString(), Color.Red, e.X, e.Y, 100, 50);
                shapes.Add(s);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                s = new MyEllipse(shapes.Count.ToString(), Color.Blue, e.X, e.Y, 200, 250);
                shapes.Add(s);
            }
            //MessageBox.Show("");
            if (s != null)
            {
                Invalidate(s.ShapeBounds);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (Shape s in shapes)
            {
                s.Draw(e.Graphics);
            }
        }

        public static DrawMode CurrentDrawMode
        {
            get;
            set;
        }

        public enum DrawMode
        {
            Pen, Shapes
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            oldMouseLocation = e.Location;
            mouseDown = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentDrawMode == DrawMode.Pen)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && mouseDown)
                {
                    Graphics g = this.CreateGraphics();
                    Pen myPen = new Pen(Color.Black, 1);
                    GraphicsPath path = new GraphicsPath(FillMode.Winding);
                    path.AddLine(oldMouseLocation, e.Location);
                    g.DrawPath(myPen, path);
                    oldMouseLocation = e.Location;
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
