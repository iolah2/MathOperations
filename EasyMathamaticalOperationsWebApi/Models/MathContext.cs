using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp.Data.Models
{
    public class MathDbContext:DbContext
    {
        public MathDbContext()
        {

        }
        public MathDbContext(DbContextOptions<MathDbContext> options):base(options)
        {

        }
        public virtual DbSet<Calculation> Calculations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=MathDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calculation>().ToTable("Calculation");
        }
    }
}
