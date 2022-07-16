using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
       
        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Type = "Animal";
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string  Gender { get; set; }

        public string Type { get; set; }

        public virtual string ProduceSound()
        {
            return "";
        }
        

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Type);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(ProduceSound());
            return sb.ToString();
        }
    }
}
