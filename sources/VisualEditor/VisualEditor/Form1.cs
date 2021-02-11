using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VisualEditor
{
    public partial class VEform : Form
    {
        Figure figure;

        List<Figure> figureList = new List<Figure>();

        public VEform()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.fgr)|*.fgr";
            saveFileDialog1.Filter = "Text files(*.fgr)|*.fgr";
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            int X = e.X;
            int Y = e.Y;

            bool check = true;
            KeyPreview = true;

            int maxX = pictureBox1.ClientSize.Width;
            int maxY = pictureBox1.ClientSize.Height;

            foreach (var f in figureList)
            {
                if (f.InsideFigure(X, Y))
                {
                    f.BoldFigure();

                    check = false;

                    break;
                }
            }

            if (EllipseRadioButton.Checked)
            {
                figure = new Ellipse(X, Y);
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
                figure.BorderControl(maxX, maxY);

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
            foreach (var f in figureList.ToArray())
            {
                int maxX = pictureBox1.ClientSize.Width;
                int maxY = pictureBox1.ClientSize.Height;

                if (f.Bold)
                {
                    if (e.Control)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Up:
                                f.MoveUp(maxX, maxY);
                                break;

                            case Keys.Right:
                                f.MoveRight(maxX, maxY);
                                break;

                            case Keys.Down:
                                f.MoveDown(maxX, maxY);
                                break;

                            case Keys.Left:
                                f.MoveLeft(maxX, maxY);
                                break;

                            case Keys.OemMinus:
                                f.Decrease(maxX, maxY);
                                break;

                            case Keys.Oemplus:
                                f.Increase(maxX, maxY);
                                break;

                            case Keys.Delete:
                                figureList.Remove(f);
                                break;
                        }
                    }
                }

                Refresh();

            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            figureList.Clear();

            Refresh();
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                foreach (var f in figureList)
                {
                    if (f.Bold)
                    {
                        f.ChangeColor(colorDialog1.Color);
                    }
                }
            }

            Refresh();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Name = saveFileDialog1.FileName;

                File.WriteAllLines(Name, FigureDataArr());
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Name = openFileDialog1.FileName;

                using (StreamReader sr = new StreamReader(Name, System.Text.Encoding.UTF8))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        var dataLine = line.Split(',');

                        switch (dataLine[0])
                        {
                            case "Circle":
                                figure = new Circle();
                                figure.Load(dataLine);
                                figureList.Add(figure);
                                break;
                            case "Square":
                                figure = new Square();
                                figure.Load(dataLine);
                                figureList.Add(figure);
                                break;
                            case "Rectangle":
                                figure = new Rectangle();
                                figure.Load(dataLine);
                                figureList.Add(figure);
                                break;
                            case "Line":
                                figure = new Line();
                                figure.Load(dataLine);
                                figureList.Add(figure);
                                break;
                            case "Ellipse":
                                figure = new Ellipse();
                                figure.Load(dataLine);
                                figureList.Add(figure);
                                break;
                        }
                    }
                }

                Refresh();
            }
        }

        private string[] FigureDataArr()
        {
            int length = figureList.Count();

            var figureData = new string[length];

            for (int i = 0; i < figureList.Count; i++)
            {
                figureData[i] = figureList[i].FigureData();
            }

            return figureData;
        }
    }
}
