using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable()&&!racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            double racerOneChanceOfWining = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double racerTwoChanceOfWining = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerOne.RacingBehavior=="strict")
            {
                racerOneChanceOfWining *= 1.2;
            }
            else
            {
                racerOneChanceOfWining *= 1.1;
            }
            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoChanceOfWining *= 1.2;
            }
            else
            {
                racerTwoChanceOfWining *= 1.1;
            }

            string winnerUsername;
            if (racerOneChanceOfWining>racerTwoChanceOfWining)
            {
                winnerUsername = racerOne.Username;
            }
            else
            {
                winnerUsername=racerTwo.Username;
            }

            racerOne.Race();
            racerTwo.Race();

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winnerUsername} is the winner!";
        }
    }
}
