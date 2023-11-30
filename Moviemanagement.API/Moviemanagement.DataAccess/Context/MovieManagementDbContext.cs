using Microsoft.EntityFrameworkCore;
using Moviemanagement.Domain.Entities;

namespace Moviemanagement.DataAccess.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options)
            : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Biography> Biographys { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                    new Actor { Id = 1, FirstName = "Chuck", LastName = "Norris" },
                    new Actor { Id = 2, FirstName = "Jane", LastName = "Doe" },
                    new Actor { Id = 3, FirstName = "Van", LastName = "Damme" }
                );

            modelBuilder.Entity<Movie>().HasData(
                    new Movie { Id = 1, Name = "Wakanda Forever", Description = "Box Office we coming", ActorId = 1 },
                    new Movie { Id = 2, Name = "Wakanda Forever", Description = "Box Office we coming", ActorId = 2 },
                    new Movie { Id = 3, Name = "Spiderman", Description = "Sky Scrappers be warned", ActorId = 1 },
                    new Movie { Id = 4, Name = "Matrix", Description = "Blue or Red Pill", ActorId = 3 }
                );

        }
    }
}
