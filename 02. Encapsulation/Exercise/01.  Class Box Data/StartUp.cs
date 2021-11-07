using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            if (box.Length > 0 && box.Width > 0 && box.Height > 0)
            {
                box.CalculateSurfaceArea();
                box.CalculateLiteralSurfaceArea();
                box.CalculateVolume();
            }
          


        }
    }
}
