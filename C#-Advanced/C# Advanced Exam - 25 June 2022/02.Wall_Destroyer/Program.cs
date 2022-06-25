using System;

namespace _02.Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int vRow = 0;
            int vCol = 0;
            int countOfHoles = 1;
            int countOfRods = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    wall[i, j] = input[j];
                    if (input[j]=='V')
                    {
                        vRow = i;
                        vCol = j;
                    }
                }
            }
            bool isElectrocuted = false;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up")
                {
                    if (IsInside(n, vRow-1, vCol))
                    {
                        if (wall[vRow-1,vCol]=='R')
                        {
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else
                        {
                            wall[vRow, vCol] = '*';
                            vRow--;
                            if (wall[vRow, vCol] == 'C')
                            {
                                wall[vRow, vCol] = 'E';
                                countOfHoles++;
                                isElectrocuted = true;
                                break;
                            }
                            else if (wall[vRow, vCol] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                                wall[vRow, vCol] = 'V';
                            }
                            else if (wall[vRow, vCol] == '-')
                            {
                                wall[vRow, vCol] = 'V';
                                countOfHoles++;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "down")
                {
                    if (IsInside(n, vRow + 1, vCol))
                    {
                        if (wall[vRow + 1, vCol] == 'R')
                        {
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else
                        {
                            wall[vRow, vCol] = '*';
                            vRow++;
                            if (wall[vRow, vCol] == 'C')
                            {
                                wall[vRow, vCol] = 'E';
                                countOfHoles++;
                                isElectrocuted = true;
                                break;
                            }
                            else if (wall[vRow, vCol] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                                wall[vRow, vCol] = 'V';
                            }
                            else if (wall[vRow, vCol] == '-')
                            {
                                wall[vRow, vCol] = 'V';
                                countOfHoles++;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "left")
                {
                    if (IsInside(n, vRow , vCol-1))
                    {
                        if (wall[vRow , vCol-1] == 'R')
                        {
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else
                        {
                            wall[vRow, vCol] = '*';
                            vCol--;
                            if (wall[vRow, vCol] == 'C')
                            {
                                wall[vRow, vCol] = 'E';
                                countOfHoles++;
                                isElectrocuted = true;
                                break;
                            }
                            else if (wall[vRow, vCol] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                                wall[vRow, vCol] = 'V';
                            }
                            else if (wall[vRow, vCol] == '-')
                            {
                                wall[vRow, vCol] = 'V';
                                countOfHoles++;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "right")
                {
                    if (IsInside(n, vRow , vCol+1))
                    {
                        if (wall[vRow , vCol+1] == 'R')
                        {
                            countOfRods++;
                            Console.WriteLine("Vanko hit a rod!");
                        }
                        else
                        {
                            wall[vRow, vCol] = '*';
                            vCol++;
                            if (wall[vRow, vCol] == 'C')
                            {
                                wall[vRow, vCol] = 'E';
                                countOfHoles++;
                                isElectrocuted = true;
                                break;
                            }
                            else if (wall[vRow, vCol] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                                wall[vRow, vCol] = 'V';
                            }
                            else if (wall[vRow, vCol] == '-')
                            {
                                wall[vRow, vCol] = 'V';
                                countOfHoles++;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Join("", wall[i,j]));
                }
                Console.WriteLine();
            }
        }
        static bool IsInside(int n , int row, int col)
        {
            return row>=0 && col>=0 && row<n && col < n;
        }

    }
}
