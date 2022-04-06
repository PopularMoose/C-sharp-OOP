using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories.Contracts
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.vessels.AsReadOnly();

        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public IVessel FindByName(string name)
        
          =>  this.vessels.FirstOrDefault(x=> x.GetType().Name == name);
        

        public bool Remove(IVessel model)
       => this.vessels.Remove(model);
    }
}
