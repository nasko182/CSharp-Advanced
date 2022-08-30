using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> bunnies;
        public BunnyRepository()
        {
            this.bunnies = new HashSet<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>)bunnies;

        public void Add(IBunny model)=>bunnies.Add(model);

        public IBunny FindByName(string name) => 
            bunnies.FirstOrDefault(b=>b.Name==name);

        public bool Remove(IBunny model) => bunnies.Remove(model);
        
    }
}
