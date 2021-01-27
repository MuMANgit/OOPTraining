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

        public bool Bold { get; set; }

        public int Width{ get; set; }
        public int Height { get; set; }

        public Figure()
        {

        }

        public Figure(int x, int y)
        {
            X = x;
            Y = y;   
        }

        public abstract void DrawYourself(Graphics g);
    }
}
