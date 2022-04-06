using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {

        }

        public bool SubmergeMode { get => submergeMode; set => submergeMode = false; }

        public void ToggleSubmergeMode()
        {
            if (submergeMode == true)
            {
                submergeMode = false;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                submergeMode = true;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");
            sb.AppendLine($"*Targets: {(this.Targets.Any() ? string.Join(", ", this.Targets) : "None")}");
            if (submergeMode)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
