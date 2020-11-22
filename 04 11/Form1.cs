using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace _04_11
{
    public partial class Form1 : Form
    {
        int but = 100;
        bool isDrawing = false;
        Rectangle currentRect;
        Point p1 = new Point();
        Point p2 = new Point();
        Pen pen = new Pen(Color.LimeGreen, 6);
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            but = 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            but = 2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            but = 3;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            but = 4;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            but = 5;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (but == 4)
            {
                isDrawing = true;
                currentRect.Location = e.Location;
            }
            if (but == 1)
            {
                isDrawing = true;
                currentRect.Location = e.Location;
            }
            if (but == 3)
            {
                if (e.Button == MouseButtons.Left)
                    p1 = e.Location;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (var r in rectangles)
            {
                g.DrawRectangle(Pens.LimeGreen, r);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (but == 4)
            {
                isDrawing = false;

                if (e.X > currentRect.X)
                    currentRect.Width = e.X - currentRect.X;
                else
                {
                    currentRect.Width = currentRect.X - e.X;
                    currentRect.X = e.X;
                }
                if (e.Y > currentRect.Y)
                    currentRect.Height = e.Y - currentRect.Y;
                else
                {
                    currentRect.Height = currentRect.Y - e.Y;
                    currentRect.Y = e.Y;
                }
                rectangles.Add(currentRect);
                this.CreateGraphics().DrawEllipse(Pens.LimeGreen, currentRect);
            }
            if (but == 1)
            {
                isDrawing = false;

                if (e.X > currentRect.X)
                    currentRect.Width = e.X - currentRect.X;
                else
                {
                    currentRect.Width = currentRect.X - e.X;
                    currentRect.X = e.X;
                }
                if (e.Y > currentRect.Y)
                    currentRect.Height = e.Y - currentRect.Y;
                else
                {
                    currentRect.Height = currentRect.Y - e.Y;
                    currentRect.Y = e.Y;
                }
                rectangles.Add(currentRect);
                this.CreateGraphics().DrawRectangle(Pens.LimeGreen, currentRect);
            }
            if (but == 3)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p2 = e.Location;
                    Graphics g = this.CreateGraphics();
                    g.DrawLine(pen, p1, p2);
                }
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (but == 2)
            {
                Point point = e.Location;
                points.Add(point);
                this.CreateGraphics().FillEllipse(Brushes.LimeGreen, point.X - 5, point.Y - 5, 10F, 10F);
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (but == 5)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point point = e.Location;
                    points.Add(point);
                    this.CreateGraphics().FillEllipse(Brushes.LimeGreen, point.X - 5, point.Y - 5, 10F, 10F);
                }
            }
        }
    }
}
