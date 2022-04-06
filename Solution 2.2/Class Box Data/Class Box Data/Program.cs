using System;

namespace Class_Box_Data
{
   public  class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;
            try
            {
                box = new Box(length,width,height);
              
            }
            catch (ArgumentException )
            {

                if (length == 0)
                {
                    Console.WriteLine($"Length cannot be zero or negative."); 
                    
                }
                else if (width == 0)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                }
                else if (height == 0)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                }

            }
            

            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Suface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
    }
}
