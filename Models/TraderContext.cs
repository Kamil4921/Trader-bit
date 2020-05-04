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
                optionsBuilder.UseSqlite("Data source=TraderBit.db");
            }
        }
    }
}
