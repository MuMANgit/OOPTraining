using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualEditor
{
    class Circle : Figure
    {
        public Circle()
        {

        }
        public Circle(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }
        public override void DrawYourself(Graphics g)
        {
            Pen penPurple = new Pen(Color.Black, 2);

            g.DrawEllipse(penPurple, X - Width / 2, Y - Height / 2, Width, Height);
        }
    }
}
