using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            var sb = new StringBuilder();
            int width = radius*4+1;
            int height = radius*2+1;
            char[,] field = new char[height,width];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = ' ';
                }
            }
            DrawUpRight(field);
            DrawUpLeft(field);
            DrawDownRight(field);
            DrawDownLeft(field);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    sb.Append(field[i, j]);
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
        private void DrawUpRight(char[,] field)
    {
            int row = 0;
            int col = radius * 2;
            field[row, col] = '*';
            col++;
            for (int i = col; i <= radius * 2 + radius; i++)
            {
                field[row, i] = '*';
                col++;
            }
            while (true)
            {
                row++;
                field[row, col] = '*';
                col++;
                if (col < field.GetLength(1))
                {
                    field[row, col] = '*';
                }
                else
                {
                    break;
                }
            }
        }

        private void DrawUpLeft(char[,] field)
        {
            int row = 0;
            int col = radius * 2-1;
            for (int i = col; i >= radius * 2 - radius; i--)
            {
                field[row, i] = '*';
                col--;
            }
            while (true)
            {
                row++;
                field[row, col] = '*';
                col--;
                if (col >= 0)
                {
                    field[row, col] = '*';
                }
                else
                {
                    break;
                }
            }
        }

        private void DrawDownRight(char[,] field)
        {
            int row = field.GetLength(0)-1;
            int col = radius * 2;
            field[row, col] = '*';
            col++;
            for (int i = col; i <= radius * 2 + radius; i++)
            {
                field[row, i] = '*';
                col++;
            }
            while (true)
            {
                row--;
                field[row, col] = '*';
                col++;
                if (col < field.GetLength(1))
                {
                    field[row, col] = '*';
                }
                else
                {
                    break;
                }
            }
        }

        private void DrawDownLeft(char[,] field)
        {
            int row = field.GetLength(0)-1;
            int col = radius * 2 - 1;
            for (int i = col; i >= radius * 2 - radius; i--)
            {
                field[row, i] = '*';
                col--;
            }
            while (true)
            {
                row--;
                field[row, col] = '*';
                col--;
                if (col >= 0)
                {
                    field[row, col] = '*';
                }
                else
                {
                    break;
                }
            }
        }

    }
}
