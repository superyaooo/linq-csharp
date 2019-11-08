using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
//            var cars = ProcessCars("fuel.csv");

            /*var query = cars.OrderByDescending(c => c.Combined)
                .ThenBy(c=>c.Name);   // secondary sort .ThenBy()
            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

            var top = cars.OrderByDescending(c=>c.Combined)
                .ThenBy(c=>c.Name)
                .Select(c=>c)
                .LastOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);
            Console.WriteLine(top?.Name);

            var any = cars.Any(c=>c.Manufacturer == "Ford");
            Console.WriteLine(any);

            var all = cars.All(c => c.Manufacturer == "Ford");
            Console.WriteLine(all);

            var result = cars.SelectMany(c => c.Name);
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }*/

//            var manufacturers = ProcessManufacturers("manufacturers.csv");

            /*var query = cars.Join(manufacturers, 
                                    c => c.Manufacturer,
                                    m => m.Name,
                                    (c,m) => new {
                                        m.Headquarters,
                                        c.Name,
                                        c.Combined
                                    })
                .OrderByDescending(c=>c.Combined)
                .ThenBy(c=>c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            }*/

            /*var query = cars.GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);

            foreach (var group in query)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c=>c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }*/



            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();

            var query = db.Cars.Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Take(10);

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }

                db.SaveChanges();
            }
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            return File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Year = int.Parse(columns[2])
                    };
                }).ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(line => line.Length > 1)
                        .Select(Car.ParseFromCsv)
                        .ToList();
        }
    }
}
