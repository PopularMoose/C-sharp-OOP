using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => this.cars.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            this.cars.Add(model); 
        }

        public ICar FindBy(string property)
        {
            
                return this.cars.FirstOrDefault(x => x.VIN == property);
            
        }

        public bool Remove(ICar model)
        => this.cars.Remove(model);
    }
}
