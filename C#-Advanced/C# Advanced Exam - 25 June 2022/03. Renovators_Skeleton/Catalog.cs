using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators = new List<Renovator>();

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count { get => renovators.Count; }

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)||string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (NeededRenovators<=Count)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";

            }
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Any(r=>r.Name==name))
            {
                var renovator = renovators.First(r => r.Name == name);
                renovators.Remove(renovator);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Count();
            renovators.RemoveAll(r=>r.Type==type);
            return count-renovators.Count;
        }

        public Renovator HireRenovator (string name)
        {
            if (renovators.Any(r=>r.Name==name))
            {
                var renovator = renovators.First(r=>r.Name==name);
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators (int days)
        {
            return renovators.Where(r=>r.Days>=days).ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
