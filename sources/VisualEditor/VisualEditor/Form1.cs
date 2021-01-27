using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualEditor
{
    public partial class VEform : Form
    {
        Figure figure;

        List<Figure> figureList = new List<Figure>();
        public VEform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (figure is Square)
            {
                figure = new Square(e.X, e.Y, 25, 25);    
            }
            else if(figure is Circle)
            {
                figure = new Circle(e.X, e.Y, 25, 25);   
            }
            else if(figure is Line)
            {
                figure = new Line(e.X, e.Y);
            }
            else if(figure is Triangle)
            {
                figure = new Triangle(e.X, e.Y);
            }
            else
            {
                MessageBox.Show("Выберите Фигуру");
            }

            figureList.Add(figure);
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var figure in figureList)
            {
                figure.DrawYourself(g);
            }
        }

        private void BlueButton_Click(object sender, EventArgs e)
        {

        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            figure = new Square();
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            figure = new Circle();
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            figure = new Line();
        }
        private void TriangleButton_Click(object sender, EventArgs e)
        {
            figure = new Triangle();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            Refresh();
        }   
    }
}
