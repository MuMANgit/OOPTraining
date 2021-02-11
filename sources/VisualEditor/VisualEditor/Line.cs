using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VisualEditor
{
    class Line : Figure
    {
        public int Width { get; set; } = 60;

        public Line()
        {

        }

        public Line(int x, int y) : base(x, y)
        {

        }

        public Line(int x, int y, int width) : this(x, y)
        {
            Width = width;
        }
        public override void DrawYourself(Graphics g)
        {
            Pen pen = new Pen(_Color, 2);
            Pen penBold = new Pen(_Color, 5);

            g.DrawLine(Bold ? penBold : pen, X - Width / 2, Y, X + Width / 2, Y);
        }


        public override bool InsideFigure(int x, int y)
        {


            if (x > X - Width / 2 && x < X + Width / 2 && y == Y)
            {
                return true;
            }
            return false;
        }

        public override void Decrease()
        {
            if (Width > 5)
            {
                Width -= 5;
            }
        }

        public override void Increase(int maxX, int maxY)
        {
            if (X + Width / 2 < maxX && X - Width / 2 > 0)
            {
                Width += 5;
            }
        }

        public override void BorderControl(int maxX, int maxY)
        {
            int minX = 0;
            int minY = 0;
            if (X + Width / 2 > maxX)
            {
                X = maxX - Width / 2;
            }
            if (X - Width / 2 < minX)
            {
                X = minX + Width / 2;
            }
            if (Y > maxY)
            {
                Y = maxY;
            }
            if (Y < minY)
            {
                Y = minY;
            }
        }

        public override string FigureData()
        {
            string data = $"Line, {X}, {Y}, {Width}, {_Color.ToArgb()}";

            return data;
        }

        public override void Load(string[] dataLine)
        {
            X = int.Parse(dataLine[1]);
            Y = int.Parse(dataLine[2]);
            Width = int.Parse(dataLine[3]);
            _Color = Color.FromArgb(int.Parse(dataLine[4]));
        }
    }
}
