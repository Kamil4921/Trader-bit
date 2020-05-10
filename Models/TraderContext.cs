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
                optionsBuilder.UseSqlServer("Server=DESKTOP-2ASIN7C\\SQLEXPRESS;Database=TraderBit;user id=kamilkamil1;pwd=kamil;");
            }
        }
    }
}
