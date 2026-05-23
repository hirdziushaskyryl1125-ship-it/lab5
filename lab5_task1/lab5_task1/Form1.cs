using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_task1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int mode = 1;
        int overlapMode = 0;

        Rectangle rect;
        Rectangle ellipse;
        Rectangle circle;

        Point[] hexagon;

        private void GenerateFigures()
        {
            Rectangle tempRect;
            do
            {
                int rectWidth = rnd.Next(60, 150);
                int rectHeight = rnd.Next(40, 100);

                while (rectWidth == rectHeight)
                {
                    rectHeight = rnd.Next(40, 100);
                }

                tempRect = new Rectangle(
                    rnd.Next(20, 500),
                    rnd.Next(20, 300),
                    rectWidth,
                    rectHeight);

            } while (overlapMode == 1 && Intersects(tempRect));

            rect = tempRect;

            Rectangle tempEllipse;

            do
            {
                tempEllipse = new Rectangle(
                    rnd.Next(20, 500),
                    rnd.Next(20, 300),
                    rnd.Next(80, 180),
                    rnd.Next(40, 120));

            } while (overlapMode == 1 && Intersects(tempEllipse));

            ellipse = tempEllipse;

            Rectangle tempCircle;

            do
            {
                int size = rnd.Next(50, 120);

                tempCircle = new Rectangle(
                    rnd.Next(20, 500),
                    rnd.Next(20, 300),
                    size,
                    size);

            } while (overlapMode == 1 && Intersects(tempCircle));

            circle = tempCircle;

            Point[] tempHex;
            Rectangle hexBounds;

            do
            {
                int centerX = rnd.Next(100, 500);
                int centerY = rnd.Next(100, 300);
                int radius = rnd.Next(40, 80);

                tempHex = new Point[6];

                int minX = int.MaxValue, minY = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue;

                for (int i = 0; i < 6; i++)
                {
                    double angle = Math.PI / 3 * i;

                    int x = centerX + (int)(radius * Math.Cos(angle));
                    int y = centerY + (int)(radius * Math.Sin(angle));

                    tempHex[i] = new Point(x, y);

                    minX = Math.Min(minX, x);
                    minY = Math.Min(minY, y);
                    maxX = Math.Max(maxX, x);
                    maxY = Math.Max(maxY, y);
                }

                hexBounds = new Rectangle(minX, minY, maxX - minX, maxY - minY);

            } while (overlapMode == 1 && Intersects(hexBounds));

            hexagon = tempHex;
        }
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            GenerateFigures();
        }

        private bool Intersects(Rectangle r)
        {
            if (rect != null && r.IntersectsWith(rect)) return true;
            if (ellipse != null && r.IntersectsWith(ellipse)) return true;
            if (circle != null && r.IntersectsWith(circle)) return true;

            return false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Q)
            {
                GenerateFigures();
                Invalidate();
            }

            if (e.KeyCode == Keys.W)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.D1)
            {
                mode = 1;
                Invalidate();
            }

            if (e.KeyCode == Keys.D2)
            {
                mode = 2;
                Invalidate();
            }

            if (e.KeyCode == Keys.D3)
            {
                mode = 3;
                Invalidate();
            }

            if (e.KeyCode == Keys.Z)
            {
                overlapMode = 0;
                Invalidate();
            }

            if (e.KeyCode == Keys.X)
            {
                overlapMode = 1;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (mode == 1)
            {
                g.DrawRectangle(Pens.Black, rect);
                g.FillEllipse(Brushes.Green, ellipse);
                g.DrawEllipse(Pens.Red, circle);
                g.FillPolygon(Brushes.Orange, hexagon);
            }
            else if (mode == 2)
            {
                g.FillRectangle(Brushes.Gray, rect);
                g.FillEllipse(Brushes.Green, ellipse);
                g.FillEllipse(Brushes.Red, circle);
                g.FillPolygon(Brushes.Orange, hexagon);
            }
            else if (mode == 3)
            {
                g.DrawRectangle(Pens.Black, rect);
                g.DrawEllipse(Pens.Green, ellipse);
                g.DrawEllipse(Pens.Red, circle);
                g.DrawPolygon(Pens.Orange, hexagon);
            }
        }
    }
}