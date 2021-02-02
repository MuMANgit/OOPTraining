using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace VisualEditor
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Color _Color { get; set; } = Color.Black;

        public bool Bold { get; set; } = false;
       
        public Figure(int x, int y)
        {
            X = x;
            Y = y;   
        }

        public abstract void DrawYourself(Graphics g);
        public abstract bool InsideFigure(int x, int y);

        public abstract void Decrease();

        public abstract void Increase();

        public void BoldFigure()
        {
            Bold = !Bold;
        }

        public void ChangeColor(Color color)
        {
            _Color = color;
        }

        public void MoveLeft()
        {
            X -= 10;
        }

        public void MoveUp()
        {
            Y -= 10;
        }

        public void MoveDown()
        {
            Y += 10;
        }

        public void MoveRight()
        {
            X += 10;
        }

    }
}
