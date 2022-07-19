using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            var sb = new StringBuilder();
            char[,] field = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i==0||i==height-1)
                    {
                        field[i, j] = '*';
                    }
                    else if (j==0||j==width-1)
                    {
                        field[i, j] = '*';
                    }
                    else
                    {
                        field[i, j] = ' ';
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.Append(field[i, j]);
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
