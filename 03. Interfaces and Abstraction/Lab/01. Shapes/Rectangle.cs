using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int _width, int _height)
        {
            this.width = _width;
            this.height = _height;
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int _width, char _end, char _mid)
        {
            Console.Write(_end);
            for (int i = 1; i < _width - 1; ++i)
            {
                Console.Write(_mid);
            }
            Console.WriteLine(_end);
        }
    }
}
