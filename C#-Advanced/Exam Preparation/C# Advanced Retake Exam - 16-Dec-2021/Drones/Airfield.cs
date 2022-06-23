using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; } = new List<Drone>();
        public string Name { get; }
        public int Capacity { get; }
        public double LandingStrip { get; }

        public int Count => Drones.Count;


        public Airfield(string name, int capacity,double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (!string.IsNullOrEmpty(drone.name)&&!string.IsNullOrEmpty(drone.brand)
                &&drone.range>=5&&drone.range<=15)
            {
                if (Drones.Count>=Capacity)
                {
                    return "Airfield is full.";
                }
                else
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.name} to the airfield.";
                }
            }
            else
            {
                return "Invalid drone.";
            }
        }

        public bool RemoveDrone(string name)
        {
            bool isRemoverd = false;
            if (Drones.Any(d=>d.name==name))
            {
                var drone = Drones.FirstOrDefault(d=>d.name==name);
                Drones.Remove(drone);
                isRemoverd = true;
            }
            return isRemoverd;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.Count;
            Drones.RemoveAll(d => d.brand == brand);
            return count - Drones.Count;
        }

        public Drone FlyDrone (string name)
        {
            Drone drone = null;
            if (Drones.Any(d=>d.name==name))
            {
                drone = Drones.First(d => d.name == name);
                drone.available = false;
            }
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();
            foreach (var drone in Drones)
            {
                if (drone.range>=range)
                {
                    drone.available = false;
                    drones.Add(drone);
                }
            }
            return drones;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones)
            {
                if (drone.available==true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

    }
}
