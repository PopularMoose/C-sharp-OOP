using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException();
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }





        public double Height
        {
            get { return height; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException();
                     
                }
                height = value;

            }
        }



        double result = 0;

        public double SurfaceArea()
        {


            return result = 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Width * Height);

        }

        public double LateralSurfaceArea()
        {
            return result = 2 * (Length * Height) + 2 * (Width * Height);
        }

        public double Volume()
        {
            return result = Length * Width * Height;
        }






    }

}
