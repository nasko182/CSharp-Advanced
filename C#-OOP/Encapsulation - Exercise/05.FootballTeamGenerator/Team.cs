using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {

        private string name;
        private List<Player> players;
        private int rating;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
            this.Rating = 0;
            
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


        public int Rating
        {
            get 
            {
                if (rating==0)
                {
                    Rating = 0;
                }
                return rating;
            }
            private set { rating = CalcTeamRating(); }
        }


        public IReadOnlyCollection<Player> Players
        {
            get { return players; }
            set { players = (List<Player>)value; }
        }

        private int CalcPlayerRating(Player player)
        {
            double playerRating = 0;
            
                playerRating += player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting;

            playerRating /= 5;
            return (int)(Math.Round(playerRating)) ;
        }

        private int CalcTeamRating()
        {
            int teamRating = 0;
            foreach(Player player in players)
            {
                teamRating+= CalcPlayerRating(player);
            }
            return teamRating;
        }

        public void AddPlayer(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (endurance>=0&&endurance<101&& sprint >= 0 && sprint < 101 && dribble >= 0 && dribble < 101 && passing >= 0 && passing < 101 && shooting >= 0 && shooting < 101)
            {
                players.Add(new Player(playerName, endurance, sprint, dribble, passing, shooting));
            }
            else
            {
                var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (this.players.Any(p=>p.Name==playerName))
            {
                var currentPlayer = this.players.Find(p=>p.Name==playerName);
                this.players.Remove(currentPlayer);
                
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
            }
        }

        

    }
}
