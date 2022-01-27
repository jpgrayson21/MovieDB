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

        /*seeded entries into the database*/
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<SubmissionResponse>().HasData(
                new SubmissionResponse
                {
                    /*favorite movie of all time, felt necessary to comment this*/
                    SubmissionId = 1,
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
