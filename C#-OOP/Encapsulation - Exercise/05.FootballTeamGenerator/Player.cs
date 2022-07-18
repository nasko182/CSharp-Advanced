using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("A name should not be empty.");
                }
            }
        }


        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value>=0&&value<=100)
                {
                    endurance = value;
                }
                else
                {
                    Console.WriteLine($"Endurance should be between 0 and 100.");
                    
                }
            }
        }


        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    sprint = value;
                }
                else
                {
                    Console.WriteLine($"Sprint should be between 0 and 100.");
                }
            }
        }


        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    dribble = value;
                }
                else
                {
                    Console.WriteLine($"Dribble should be between 0 and 100.");
                }
            }
        }


        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    passing = value;
                }
                else
                {
                    Console.WriteLine($"Passing should be between 0 and 100.");
                }
            }
        }


        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    shooting = value;
                }
                else
                {
                    Console.WriteLine($"Shooting should be between 0 and 100.");
                }
            }
        }

    }
}
