using Microsoft.EntityFrameworkCore;
using TT.Domain.Entities;

namespace TT.Infrastructure.Context
{
    public class TTDbContext : DbContext
    {
        public TTDbContext(DbContextOptions<TTDbContext> options)
            : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
    }
}
