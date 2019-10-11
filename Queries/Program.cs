using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.9f, Year = 2008},
                new Movie {Title = "The White Knight", Rating = 8.1f, Year = 2009},
                new Movie {Title = "The Purple Knight", Rating = 3.9f, Year = 2003},
                new Movie {Title = "The Diamond Knight", Rating = 0.9f, Year = 2007}
            };

            var query = movies.Where(m=>m.Year > 2000);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
