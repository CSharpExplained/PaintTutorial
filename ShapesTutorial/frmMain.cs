using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintTutorial
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Canvas.CurrentDrawMode = Canvas.DrawMode.Shapes;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            CanvasTab ct = new CanvasTab("test.png");
            tabMain.TabPages.Add(ct);
            tabMain.SelectedTab = ct;
        }

        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString(this.tabMain.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            //Looping through the controls.
            for (int i = 0; i < this.tabMain.TabPages.Count; i++)
            {
                Rectangle r = tabMain.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabMain.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void tsShapes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mnubtnRec || e.ClickedItem == mnubtnOval)
            {
                Canvas.CurrentDrawMode = Canvas.DrawMode.Shapes;
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == mnubtnPen)
            {
                Canvas.CurrentDrawMode = Canvas.DrawMode.Pen;
            }
        }

        
    }
}
