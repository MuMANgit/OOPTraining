﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace VisualEditor
{
    class Square : Figure
    {
        public int Width { get; set; } = 60;
        public int Height { get; set; } = 60;
        public Square()
        {

        }

        public Square(int x, int y) : base(x, y)
        {
           
        }

        public Square(int x, int y, int width, int height) : this(x, y)
        {
            Width = width;
            Height = height;
        }

        public override void DrawYourself(Graphics g)
        {
            Pen pen = new Pen(_Color, 2);
            Pen penBold = new Pen(_Color, 5);

            g.DrawRectangle(Bold ? penBold : pen, X - Width / 2, Y - Height / 2, Width, Height);
        }

        public override bool InsideFigure(int x, int y)
        {
            if (x > X - Width / 2 && x < X + Width / 2 && y > Y - Height / 2 && y < Y + Height / 2)
            {
                return true;
            }
            return false;   
        }

        public override void Decrease()
        {
            if (Width > 5 && Height > 5)
            {
                Width -= 5;
                Height -= 5;
            }
        }

        public override void Increase(int maxX, int maxY)
        {
            if (X + Width / 2 < maxX && Y + Height / 2 < maxY && X - Width / 2 > 0 && Y - Height / 2 > 0)
            {
                Width += 5;
                Height += 5;
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

            if (Y + Height / 2 > maxY)
            {
                Y = maxY - Height / 2;
            }

            if (Y - Height / 2 < minY)
            {
                Y = minY + Height / 2;
            }
        }

        public override string FigureData()
        {
            string data = $"Square, {X}, {Y}, {Width}, {Height}, {_Color.ToArgb()}";

            return data;
        }

        public override void Load(string[] dataLine)
        {
            X = int.Parse(dataLine[1]);
            Y = int.Parse(dataLine[2]);
            Width = int.Parse(dataLine[3]);
            Height = int.Parse(dataLine[4]);
            _Color = Color.FromArgb(int.Parse(dataLine[5]));

        }
    }
}
