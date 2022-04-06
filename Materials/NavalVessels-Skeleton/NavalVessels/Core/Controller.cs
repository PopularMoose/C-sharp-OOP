using NavalVessels.Core.Contracts;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private List<ICaptain> captains;
        private VesselRepository vessels;

        public Controller()
        {
            this.captains = new List<ICaptain>();
            this.vessels = new VesselRepository();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain desireddCaptain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vesseled = this.vessels.FindByName(selectedVesselName);

            if (desireddCaptain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            else if (vesseled == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            else if (desireddCaptain.Vessels.Contains(vesseled))
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            desireddCaptain.AddVessel(vesseled);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel vessel1 = this.vessels.FindByName(attackingVesselName);
            IVessel vessel2 = this.vessels.FindByName(defendingVesselName);

            if (vessel1 == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            else if (vessel2 == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (vessel1.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            else if (vessel2.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            vessel1.Attack(vessel2);
            vessel1.Captain.IncreaseCombatExperience();
            vessel2.Captain.IncreaseCombatExperience();
            return $"Vessel {vessel2.Name} was attacked by vessel {vessel1.Name} - current armor thickness: {vessel2.ArmorThickness}.";



        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();


        }

        public string HireCaptain(string fullName)
        {
            ICaptain desiredCaptain = this.captains.FirstOrDefault(x => x.FullName == fullName);
            if (desiredCaptain == null)
            {
                this.captains.Add(desiredCaptain);
                return $"Captain {fullName} is hired.";
            }
            return $"Captain {fullName} is already hired.";

        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {

            if (name != "Submarine" && name != "Battleship")
            {
                return "Invalid vessel type";
            }

            IVessel vessel;
            if (name == "Submarine")
            {
                vessel = new Submarine(vesselType, mainWeaponCaliber, speed);
                if (vessel != null)
                {
                    return $"{vesselType} vessel {name} is already manufactured.";
                }
                vessels.Add(vessel);
            }
            else if (name == "Battleship")
            {
                vessel = new Battleship(vesselType, mainWeaponCaliber, speed);
                if (vessel != null)
                {
                    return $"{vesselType} vessel {name} is already manufactured.";
                }
                vessels.Add(vessel);
            }

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";

        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);


            if (vessel != null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vessel.Name} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel.GetType().Name == "Battleship" && vessel.GetType().Name != null)
            {

                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else if (vessels.GetType().Name == "Submarine" && vessels.GetType().Name != null)
            {
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            return $"Vessel {vesselName} could not be found.";
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();

        }
    }
}
