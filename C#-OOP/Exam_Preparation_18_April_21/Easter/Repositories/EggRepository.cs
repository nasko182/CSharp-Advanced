using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs;
        public EggRepository()
        {
            this.eggs = new HashSet<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => 
            (IReadOnlyCollection<IEgg>)eggs;


        public void Add(IEgg model)=>eggs.Add(model);

        public IEgg FindByName(string name) => 
            eggs.FirstOrDefault(e=>e.Name==name);

        public bool Remove(IEgg model)=>eggs.Remove(model);
    }
}
