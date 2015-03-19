using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintTutorial
{
    public abstract class Shape
    {
        internal string shapeId;
        internal Color color;
        internal Point origin;
        internal int x = 0, y = 0, w = 0, h = 0;

        public Shape(string id, Color c)
        {
            shapeId = id;
            color = c;
        }

        /// <summary>
        /// The unique ID of the shape. READ ONLY.
        /// </summary>
        public string Id
        {
            get
            {
                return shapeId;
            }
        }

        /// <summary>
        /// The x position of the Shape.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// The y position of the Shape.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// The width of the Shape.
        /// </summary>
        public int W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        /// <summary>
        /// The Height of the Shape.
        /// </summary>
        public int H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }

        public Rectangle ShapeBounds
        {
            get
            {
                return new Rectangle(x - origin.X, y - origin.Y, w, h);
            }
        }


        /// <summary>
        /// Returns the Area of the shape as a double. READ ONLY.
        /// </summary>
        public abstract double Area
        {
            get;
        }

        /// <summary>
        /// Draws the shape using the Graphics object provided. **Needs to be called from the OnPaint() method of the parent class**
        /// </summary>
        /// <param name="g">The Graphics object used to draw the shape.</param>
        public abstract void Draw(Graphics g);
    }
}
