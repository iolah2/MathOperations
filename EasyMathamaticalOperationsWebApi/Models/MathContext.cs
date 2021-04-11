using Microsoft.EntityFrameworkCore;

namespace MathOp.Data.Models
{
    public class MathDbContext:DbContext
    {       
        public DbSet<Calculation> Calculations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=MathDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calculation>().ToTable("Calculations");
        }
    }
}
