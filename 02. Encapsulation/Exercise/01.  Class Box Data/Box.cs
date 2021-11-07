using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double width;
        private double height;

        public Box(double _length, double _width, double _height)
        {
            this.Length = _length;
            this.Width = _width;
            this.Height = _height;
        }

        public double Length
        {
            get
            {
                return length;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        public double Width
        {
            get
            {
                return width;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }

     
        public void CalculateSurfaceArea()
        {
            double surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }


        public void CalculateLiteralSurfaceArea()
        {
            double literalSurfaceArea = (2* this.Length* this.Height) + 2 * this.Width * this.Height;
            Console.WriteLine($"Lateral Surface Area - {literalSurfaceArea:f2}");
        }


        public void CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;
            Console.WriteLine($"Volume - {volume:f2}");
        }






    }
}
