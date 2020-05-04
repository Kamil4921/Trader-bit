using Microsoft.EntityFrameworkCore;
using System;

namespace Models
{
    public class TraderContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //set your own credentials!
                optionsBuilder.UseSqlServer("Server=DESKTOP-0QPECPO\\JULADB;Database=TraderBit;user id=julajula;pwd=123qwe;");
            }
        }
    }
}
