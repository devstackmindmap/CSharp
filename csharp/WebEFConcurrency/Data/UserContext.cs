using EFConcurrency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConcurrency.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;Port=44557;Database=account;User Id=admin;Password=leapeHxTWGsesRC00lJn;");
        }
    }
}
