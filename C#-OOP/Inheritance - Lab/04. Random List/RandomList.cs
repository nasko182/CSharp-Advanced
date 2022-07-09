using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var random = new Random();
            var item = this[random.Next(0, this.Count)];
            this.Remove(item);
            return item;
            
        }
    }
}
