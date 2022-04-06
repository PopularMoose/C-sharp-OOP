using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            this.gyms = new List<IGym>();
            this.equipment = new EquipmentRepository();
            
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            
            IGym desiredGym = this.gyms.FirstOrDefault(x=> x.Name == gymName);
            if (desiredGym == null)
            {
                throw new ArgumentException("KUR");
            }
            if (athleteType == "Boxer")
            {
               var athlete = new Boxer(athleteName,motivation,numberOfMedals);
                if (desiredGym.GetType().Name != nameof(BoxingGym))
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
                desiredGym.AddAthlete(athlete);
            } 
           else 
            {
                var athlete = new Weightlifter(athleteName,motivation,numberOfMedals);
                if (desiredGym.GetType().Name != nameof(WeightliftingGym))
                {
                    throw new InvalidOperationException("The gym is not appropriate.");
                }
                desiredGym.AddAthlete(athlete);
            }

            
            return ($"Successfully added {athleteType} to {gymName}.");
            
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }
            this.equipment.Add(equipment);
            return ($"Successfully added {equipmentType}.");
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            IGym gym ;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
                gyms.Add(gym);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
            }

            
            return ($"Successfully added {gymType}.");
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x=> x.Name == gymName);
            
            return ($"The total weight of the equipment in the gym { gymName} is {Math.Round(gym.EquipmentWeight, 2)} grams.");
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment desiredEquipment = equipment.Models.FirstOrDefault(x=> x.GetType().Name == equipmentType);
            IGym desiredGym = this.gyms.FirstOrDefault(x=> x.Name == gymName);
            if (equipmentType is null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            desiredGym.AddEquipment(desiredEquipment);
            this.equipment.Remove(desiredEquipment);

            return ($"Successfully added {equipmentType} to {gymName}.");

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x=> x.Name == gymName);

            gym.Exercise();
            return ($"Exercise athletes: {gym.Athletes.Count}.");
        }
    }
}
