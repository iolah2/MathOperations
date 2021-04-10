using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp.DataBaseCreate.Models
{
    public class MathContext:DbContext
    {
        public MathContext(DbContextOptions<MathContext> options):base(options)
        {

        }
        public virtual DbSet<Calculation> Calculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calculation>().ToTable("Calculation");
        }
    }
}
