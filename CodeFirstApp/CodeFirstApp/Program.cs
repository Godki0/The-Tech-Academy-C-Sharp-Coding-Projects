using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {       
           
            
                using (var db = new TheatresContext())
                {
                    // Create and save a new Blog
                    Console.Write("Enter a name for a new Theatre: ");
                    var name = Console.ReadLine();

                    var theatre = new Theatre { Name = name };
                    db.Theatres.Add(theatre);
                    db.SaveChanges();

                    // Display all Blogs from the database
                    var query = from b in db.Theatres
                                orderby b.Name
                                select b;

                    Console.WriteLine("All theatres in the database:");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.Name);
                    }

                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int TheatreId { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
    public class TheatresContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
    }
}


     

