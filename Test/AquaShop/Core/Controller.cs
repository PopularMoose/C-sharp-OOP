using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;
        private DecorationRepository decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariums.Add(aquarium);
            return string.Format($"Successfully added {aquariumType}.");
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            this.decorations.Add(decoration);
            return string.Format($"Successfully added {decorationType}.");
        }
        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sumOfDecorations = aquarium.Decorations.Sum(x=> x.Price);
            decimal sumOfFishes = aquarium.Fish.Sum(x=> x.Price);

            decimal totalPrice = sumOfDecorations + sumOfFishes;
            return ($"The value of Aquarium { aquariumName} is { totalPrice }.");
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Invalid fish type");
            }

            IFish fish;
            IAquarium desiredAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (desiredAquarium.GetType().Name != "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }
               
            }
            else
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (desiredAquarium.GetType().Name != "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }
                
            }


            desiredAquarium.AddFish(fish);
            return string.Format($"Successfully added {fishType} to {aquariumName}.");
        }


        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(x=>x.Name == aquariumName);

            aquarium.Feed();
            return string.Format($"Fish fed{aquarium.Fish.Count}");
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration desiredDecoration = this.decorations.FindByType(decorationType);
            if (desiredDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.decorations.Remove(desiredDecoration);

            IAquarium desiredAquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            desiredAquarium.AddDecoration(desiredDecoration);
            return string.Format($"Successfully added {decorationType} to {aquariumName}.");
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo() + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
