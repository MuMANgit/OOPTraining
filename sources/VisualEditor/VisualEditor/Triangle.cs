using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEditor
{
    class Triangle : Figure
    {
        public Triangle(int x, int y) : base(x, y)
        {

        }

        public override void Decrease()
        {
            
        }

        public override void Increase()
        {
            
        }

        public override void DrawYourself(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, X, Y - 30, X + 30, Y + 30);
            g.DrawLine(pen, X, Y - 30, X - 30, Y + 30);
            g.DrawLine(pen, X - 30, Y + 30, X + 30, Y + 30);
            
        }

        public override bool InsideFigure(int x, int y)
        {
            return false;
        }
    }
}
