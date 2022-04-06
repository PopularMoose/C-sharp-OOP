using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, int fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;

            FuelConsumption = DefaultFuelConsumption;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(int kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
         

      




    }
}
