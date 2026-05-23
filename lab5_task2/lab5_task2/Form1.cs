using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab5_task2
{
    public partial class Form1 : Form
    {
        int carType = 1;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.Paint += Form1_Paint;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
                carType = 1;

            if (e.KeyCode == Keys.D2)
                carType = 2;

            if (e.KeyCode == Keys.D3)
                carType = 3;

            Invalidate(); // перемалювати
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            switch (carType)
            {
                case 1:
                    DrawBlueCar(g);
                    break;

                case 2:
                    DrawTruck(g);
                    break;

                case 3:
                    DrawGreenCar(g);
                    break;
            }
        }

        void DrawBlueCar(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3);

            // кузов
            g.FillRectangle(Brushes.Blue, 100, 150, 260, 70);
            g.DrawRectangle(p, 100, 150, 260, 70);

            // дах
            Point[] roof =
            {
        new Point(140,150),
        new Point(170,95),
        new Point(270,95),
        new Point(300,150)
    };

            g.FillPolygon(Brushes.Blue, roof);
            g.DrawPolygon(p, roof);

            // вікна
            g.FillRectangle(Brushes.LightCyan, 175, 105, 40, 35);
            g.FillRectangle(Brushes.LightCyan, 225, 105, 40, 35);

            g.DrawRectangle(p, 175, 105, 40, 35);
            g.DrawRectangle(p, 225, 105, 40, 35);

            // центральна стійка між вікнами
            g.DrawLine(p, 220, 100, 220, 140);

            // двері (лише кузов)
            g.DrawLine(p, 190, 150, 190, 220);
            g.DrawLine(p, 280, 150, 280, 220);

            // ручки
            g.FillRectangle(Brushes.Black, 165, 175, 12, 4);
            g.FillRectangle(Brushes.Black, 245, 175, 12, 4);

            // дзеркало
            g.DrawEllipse(p, 150, 125, 12, 12);

            // передня фара
            g.FillEllipse(Brushes.Yellow, 90, 170, 15, 15);

            // задня фара
            g.FillEllipse(Brushes.Red, 355, 175, 10, 12);

            // бампери
            g.FillRectangle(Brushes.Gray, 85, 205, 15, 8);
            g.FillRectangle(Brushes.Gray, 360, 205, 15, 8);

            // колеса
            g.FillEllipse(Brushes.Black, 130, 195, 65, 65);
            g.FillEllipse(Brushes.Black, 275, 195, 65, 65);

            // диски
            g.FillEllipse(Brushes.Blue, 148, 213, 28, 28);
            g.FillEllipse(Brushes.Blue, 293, 213, 28, 28);

            // дорога
            g.DrawLine(new Pen(Color.Black, 2), 50, 260, 420, 260);
        }

        void DrawTruck(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3);

            // кабіна
            g.FillRectangle(Brushes.Red, 100, 150, 100, 80);

            // вікно
            g.FillRectangle(Brushes.White, 125, 165, 40, 30);

            // кузов
            g.FillRectangle(Brushes.Purple, 200, 120, 200, 110);

            g.DrawRectangle(p, 100, 150, 100, 80);
            g.DrawRectangle(p, 200, 120, 200, 110);

            // двері
            g.DrawLine(p, 175, 150, 175, 230);

            // ручка
            g.FillRectangle(Brushes.Black, 160, 185, 10, 4);

            // кермо
            g.DrawEllipse(p, 135, 185, 15, 15);

            // фара
            g.FillEllipse(Brushes.White, 90, 180, 10, 15);

            // бампер
            g.FillRectangle(Brushes.Gray, 90, 220, 25, 10);

            // колеса
            g.FillEllipse(Brushes.Black, 120, 220, 50, 50);
            g.FillEllipse(Brushes.Black, 320, 220, 50, 50);

            g.FillEllipse(Brushes.White, 135, 235, 20, 20);
            g.FillEllipse(Brushes.White, 335, 235, 20, 20);
        }

        void DrawGreenCar(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3);

            // кузов
            g.FillRectangle(Brushes.Lime, 100, 150, 250, 60);

            // дах
            g.FillEllipse(Brushes.Lime, 130, 90, 180, 100);

            // контур
            g.DrawRectangle(p, 100, 150, 250, 60);
            g.DrawArc(p, 130, 90, 180, 100, 180, 180);

            // вікна
            g.FillRectangle(Brushes.White, 155, 115, 45, 40);
            g.FillRectangle(Brushes.White, 220, 115, 55, 40);

            g.DrawRectangle(p, 155, 115, 45, 40);
            g.DrawRectangle(p, 220, 115, 55, 40);

            // двері
            g.DrawLine(p, 210, 100, 210, 210);

            // ручка
            g.FillEllipse(Brushes.Gray, 190, 160, 15, 8);

            // кермо
            g.DrawLine(p, 245, 140, 255, 160);

            // фари
            g.FillEllipse(Brushes.White, 335, 160, 15, 15);

            // бампер
            g.DrawLine(p, 90, 210, 360, 210);

            // колеса
            g.FillEllipse(Brushes.Black, 130, 200, 50, 50);
            g.FillEllipse(Brushes.Black, 280, 200, 50, 50);

            g.FillEllipse(Brushes.White, 145, 215, 20, 20);
            g.FillEllipse(Brushes.White, 295, 215, 20, 20);
        }
    }
}