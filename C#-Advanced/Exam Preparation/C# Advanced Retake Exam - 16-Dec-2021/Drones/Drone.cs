using System.Text;

namespace Drones
{
    public class Drone
    {
        public string name;
        public string brand;
        public int range;
        public bool available = true;

        public Drone(string name, string brand, int range)
        {
            this.name = name;
            this.brand = brand;
            this.range = range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drone: {name}");
            sb.AppendLine($"Manufactured by: {brand}");
            sb.Append($"Range: {range} kilometers");

            return sb.ToString();
        }


    }
}
