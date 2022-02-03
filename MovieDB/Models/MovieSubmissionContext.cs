using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class MovieSubmissionContext : DbContext
    {
        //Constructor
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
        {
            //leaving blank for this project
        }
        public DbSet<SubmissionResponse> Submissions { get; set; }
        public DbSet<Category> Categories { get; set; }

        /*seeded entries into the database*/
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName = "Action/Adventure"},
                    new Category { CategoryID = 2, CategoryName = "Comedy"},
                    new Category { CategoryID = 3, CategoryName = "Horror/Suspense"},
                    new Category { CategoryID = 4, CategoryName = "Psychological Thriller"},
                    new Category { CategoryID = 5, CategoryName = "Sports Drama"}
                );

            mb.Entity<SubmissionResponse>().HasData(
                new SubmissionResponse
                {
                    /*favorite movie of all time, felt necessary to comment this*/
                    SubmissionId = 1,
                    CategoryID = 5,
                    Title = "Warrior",
                    Year = 2011,
                    Director = "Gavin O'Connor",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new SubmissionResponse
                {
                    SubmissionId = 2,
                    CategoryID = 1,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new SubmissionResponse
                {
                    SubmissionId = 3,
                    CategoryID = 5,
                    Title = "Cinderella Man",
                    Year = 2005,
                    Director = "Ron Howard",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
