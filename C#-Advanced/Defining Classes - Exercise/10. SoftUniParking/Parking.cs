using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity= capacity;
        }
        public List<Car> Cars { get; set; } = new List<Car>();

        public int Count => Cars.Count;


        private int capacity;

        public string AddCar(Car car)
        {
            if (Cars.Contains(car))
            {
                return ("Car with that registration number, already exists!");
            }
            if (Cars.Count>=capacity)
            {
                return ("Parking is full!");
            }
            else
            {
                Cars.Add(car);
                return ($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Any(c=>c.RegistrationNumber==registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car currentCar = Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                Cars.Remove(currentCar);
                return $"Successfully removed {registrationNumber}";
            }
        }



        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                Car currentCar = Cars.FirstOrDefault(c=>c.RegistrationNumber==registrationNumber);
                Cars.Remove(currentCar);
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = Cars.Find(c => c.RegistrationNumber==registrationNumber);
            return car;
        }
    }
}
