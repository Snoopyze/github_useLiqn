using System;
using System.Collections.Generic;
using System.Linq;

namespace use_Linq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // 2.Make list.
            List<_car> _cars = new List<_car>
            {
                new _car { brand_Vehicle = "Toyota", model_car = "Camry", year_Vehicle = 2000, price_Vehicle = 150000 },
                new _car { brand_Vehicle = "Honda", model_car = "Accord", year_Vehicle = 1995, price_Vehicle = 90000 },
                new _car { brand_Vehicle = "Ford", model_car = "Mustang", year_Vehicle = 2005, price_Vehicle = 300000 },
                new _car { brand_Vehicle = "Chevrolet", model_car = "Cruze", year_Vehicle = 2010, price_Vehicle = 180000 },
                new _car { brand_Vehicle = "BMW", model_car = "X5", year_Vehicle = 2015, price_Vehicle = 350000 } 
            };
            
            //2a
            var cars_Inrange = _cars.Where(car => car.price_Vehicle >= 10000 && car.price_Vehicle<=250000);
            Console.WriteLine("The cars are priced between 100,000 - 250,000: ");
            foreach (var car in cars_Inrange)
            {
                Console.WriteLine($"- {car.brand_Vehicle} {car.model_car}, Gia: {car.price_Vehicle} ");
            }
            //2b
            var cars_After1990s = _cars.Where(car => car.year_Vehicle >= 1990);
            Console.WriteLine("\nVehicles with production years after 1990: ");
            foreach (var car in cars_After1990s)
            {
                Console.WriteLine($"- {car.brand_Vehicle} {car.model_car}, Nam: {car.year_Vehicle}");
            }
            
            //2c
            var cars_GrByBrand = _cars.GroupBy(car => car.brand_Vehicle)
                .Select(group => new
                    {
                        Brand = group.Key,
                        TotalPrice = group.Sum(car => car.price_Vehicle)
                    });
            Console.WriteLine("\nTotal value of vehicles by manufacturer: ");
            foreach (var cars_Group in cars_GrByBrand)
            {
                Console.WriteLine($"- {cars_Group.Brand} : {cars_Group.TotalPrice}");
            }
            
            //3 
            List<_truck> trucks = new List<_truck>
            {
                new _truck { brand_Vehicle = "Volvo", year_Vehicle = 2012, price_Vehicle = 400000, company_truck = "Ngo Tenz" },
                new _truck { brand_Vehicle = "Scania", year_Vehicle = 2018, price_Vehicle = 500000, company_truck = "Ngo Tyson" },
                new _truck { brand_Vehicle = "MAN", year_Vehicle = 2010, price_Vehicle = 350000, company_truck = "Ngo Cong Anh" }
            };

            //3a
            var trucks_OrdByYear = trucks.OrderByDescending(truck => truck.year_Vehicle);
            Console.WriteLine("\nTruck list in order of latest year of manufacture:");
            foreach (var truck in trucks_OrdByYear)
            {
                Console.WriteLine($"- {truck.brand_Vehicle}, Năm: {truck.year_Vehicle}");
            }

            //3b
            var truckCompanies = trucks.Select(truck => truck.company_truck);
            Console.WriteLine("\nName of Truck's parent company:");
            foreach (var company in truckCompanies)
            {
                Console.WriteLine($"- {company}");
            }
        }
    }

    public class _vehicle
    {
        public String brand_Vehicle { get; set; }
        public int year_Vehicle { get; set; }
        public double price_Vehicle { get; set; }
        
    }

    public class _car : _vehicle
    {
        public String model_car { get; set; }
        
    }

    public class _truck : _vehicle
    {
        public String company_truck { get; set; }
    }
    
    
}