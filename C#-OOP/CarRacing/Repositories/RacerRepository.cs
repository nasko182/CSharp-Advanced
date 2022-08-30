using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> racers;

        public RacerRepository()
        {
            racers = new HashSet<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)racers;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            racers.Add(model);
        }

        public IRacer FindBy(string property)=> racers.FirstOrDefault(r=>r.Username==property);

        public bool Remove(IRacer model)=>racers.Remove(model); 
    }
}
