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

            var sales = new List<Employee>
            {
                new Employee{Id = 3, Name = "doug"}
            };
            
            Console.WriteLine(sales.Count);
        }
    }
}
