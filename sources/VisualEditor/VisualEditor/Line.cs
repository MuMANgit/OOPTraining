using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEditor
{
    class Line : Figure
    {
        public int Width { get; set; } = 60;

        public Line(int x, int y) : base(x, y)
        {

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

        public override void Increase()
        {
            if (Width < 300)
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
    }
}
