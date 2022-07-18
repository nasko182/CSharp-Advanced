using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var teams = new List<Team>();
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArgs = input.Split(';');
                    string command = inputArgs[0];
                    string teamName = inputArgs[1];
                    if (command == "Team")
                    {
                        var team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {
                        if (teams.Any(t => t.Name == teamName))
                        {
                            teams.First(t => t.Name == teamName).AddPlayer(inputArgs[2], int.Parse(inputArgs[3]), int.Parse(inputArgs[4]), int.Parse(inputArgs[5]), int.Parse(inputArgs[6]), int.Parse(inputArgs[7]));
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command == "Remove")
                    {
                        string playerName = inputArgs[2];
                        var currTeam = teams.First(t => t.Name == teamName);
                        var currPlayer = currTeam.Players.FirstOrDefault(p => p.Name == playerName);
                        if (currPlayer != null)
                        {
                            currTeam.RemovePlayer(playerName);
                        }
                        else
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                    }
                    else if (command == "Rating")
                    {
                        var currTeam = teams.FirstOrDefault(t => t.Name == teamName);
                        if (currTeam!=null)
                        {
                            Console.WriteLine($"{teamName} - {currTeam.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
            }
        }
    }
}
