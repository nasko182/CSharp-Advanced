using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new HashSet<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models
        {
            get
            {
                return (IReadOnlyCollection<IDecoration>)this.decorations;
            }
        }

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return decorations.FirstOrDefault(d=>d.GetType().Name == type); 
        }

        public bool Remove(IDecoration model)
        {
            return decorations.Remove(model);
        }
    }
}
