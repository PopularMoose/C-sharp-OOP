using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = sonarMode;
        }

        public bool SonarMode { get => sonarMode; set => sonarMode = false; }

        public void ToggleSonarMode()
        {
            if (sonarMode == true)
            {
                sonarMode = false;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                sonarMode = true;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
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
            if (sonarMode)
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
