using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace VisualEditor
{
    class Square : Figure
    {
        public Square()
        {

        }

        public Square(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }
        public override void DrawYourself(Graphics g)
        {
            Pen penPurple = new Pen(Color.Black, 2);

            g.DrawRectangle(penPurple, X - Width / 2, Y - Height / 2, Width, Height);
        }
    }
}
