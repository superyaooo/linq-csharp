using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var developers = new Employee[]
            {
                new Employee{Id = 1, Name = "bob"},
                new Employee{Id = 2,Name = "pop"} 
            };

            var sales = new List<Employee>()
            {
                new Employee{Id = 3, Name = "doug"}
            };

            foreach (var employee in developers.Where(e=>e.Name.Length == 3)
                                                .OrderBy(e=>e.Name))
            {
                Console.WriteLine(employee.Name);
            }

            // last param is return type; Linq uses Func<>
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            // return type void
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(3,5)));

            Console.WriteLine("");
        }
    }
}
