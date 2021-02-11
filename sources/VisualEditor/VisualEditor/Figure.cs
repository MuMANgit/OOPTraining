using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace VisualEditor
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Color _Color { get; set; } = Color.Black;

        public bool Bold { get; set; } = false;
        public Figure()
        {

        }
       
        public Figure(int x, int y)
        {
            X = x;
            Y = y;   
        }

        public void BoldFigure()
        {
            Bold = !Bold;
        }

        public void ChangeColor(Color color)
        {
            _Color = color;
        }

        public void MoveLeft(int maxX, int maxY)
        {
            X -= 10;

            BorderControl(maxX, maxY);
        }

        public void MoveUp(int maxX, int maxY)
        {
            Y -= 10;

            BorderControl(maxX, maxY);
        }

        public void MoveDown(int maxX, int maxY)
        {
            Y += 10;

            BorderControl(maxX, maxY);
        }

        public void MoveRight(int maxX, int maxY)
        {
            X += 10;

            BorderControl(maxX, maxY);
        }

        public abstract void DrawYourself(Graphics g);
        public abstract bool InsideFigure(int x, int y);
        public abstract void Decrease();
        public abstract void Increase(int maxX, int maxY);
        public abstract void BorderControl(int maxX, int maxY);
        public abstract string FigureData();
        public abstract void Load(string[] data);
    }
}
