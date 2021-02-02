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
            int X = e.X;
            int Y = e.Y;
            bool check = true;
            KeyPreview = true;


            foreach (var f in figureList)
            {
                if (f.InsideFigure(X, Y))
                {
                    f.BoldFigure();

                    check = false;

                    break;
                }
            }
            
            if (TriangleRadioButton.Checked)
            {
                figure = new Triangle(X, Y);
            }
            else if (SquareRadioButton.Checked)
            {
                figure = new Square(X, Y);
            }
            else if (RectangleRadioButton.Checked)
            {
                figure = new Rectangle(X, Y);
            }
            else if (LineRadioButton.Checked)
            {
                figure = new Line(X, Y);
            }
            else if (CircleRadioButton.Checked)
            {
                figure = new Circle(X, Y);
            }

            if (figure != null && check)
            {
                figureList.Add(figure);
            }
            
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

        private void VEform_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var f in from f in figureList
                              where f.Bold
                              select f)
            {
                if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            f.MoveUp();
                            break;

                        case Keys.Right:
                            f.MoveRight();
                            break;

                        case Keys.Down:
                            f.MoveDown();
                            break;

                        case Keys.Left:
                            f.MoveLeft();
                            break;

                        case Keys.OemMinus:
                            f.Decrease();
                            break;
                        case Keys.Oemplus:
                            f.Increase();
                            break;
                    }

                }

                Refresh();
            }
        }

        private void YellowButton_Click(object sender, EventArgs e)
        {
            foreach (var f in figureList)
            {
                if (f.Bold)
                {
                    f.ChangeColor(Color.Yellow);
                }
            }

            Refresh();
        }

        private void GreenButton_Click(object sender, EventArgs e)
        {
            foreach (var f in figureList)
            {
                if (f.Bold)
                {
                    f.ChangeColor(Color.Green);
                }
            }

            Refresh();
        }

        private void RedButton_Click(object sender, EventArgs e)
        {
            foreach (var f in figureList)
            {
                if (f.Bold)
                {
                    f.ChangeColor(Color.Red);
                }
            }

            Refresh();
        }

        private void BlackButton_Click(object sender, EventArgs e)
        {
            foreach (var f in figureList)
            {
                if (f.Bold)
                {
                    f.ChangeColor(Color.Black);
                }
            }

            Refresh();
        }

        private void BlueButton_Click(object sender, EventArgs e)
        {
            foreach (var f in figureList)
            {
                if (f.Bold)
                {
                    f.ChangeColor(Color.Blue);
                }
            }

            Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            figureList.Clear();

            Refresh();
        }
    }
}
