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
        public Line()
        {

        }
        public Line(int x, int y) : base(x, y)
        {

        }
        public override void DrawYourself(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, X - 30, Y, X + 30, Y);
        }
    }
}
