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

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne} wins the race! {racerTwo} was not available to race!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo} wins the race! {racerOne} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();
            IRacer winner;

            double chanceOfWinningRacerOne = 0;
            double chanceofWinningRacerTwo = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }


            if (racerTwo.RacingBehavior == "strict")
            {
                chanceofWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceofWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }

            if (chanceOfWinningRacerOne > chanceofWinningRacerTwo)
            {
                winner = racerOne;

            }
            else
            {
                winner = racerTwo;
            }
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
