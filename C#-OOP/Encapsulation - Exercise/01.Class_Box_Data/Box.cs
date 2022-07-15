using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        public Box(double length, double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get => length;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length");
                }
                length = value;
            }
        }

        public double Width
        {
            get => width; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width");
                }
                width = value;
            }
        }

        public double Height
        {
            get => height; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height");
                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Height * this.Width;
        }

        public double LateralSurfceArea()
        {
            return 2 * this.Height * (this.Length + this.Width);
        }

        public double Volume()
        {
            return this.Length* this.Width*this.Height;
        }
    }
}
