using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StdModelCore;

namespace EFCoreSample
{
    public class Context : DbContext
    {
        private string connectionString = TYPE YOUR CONNECTION STRING HERE!
        
        public DbSet<Person> Person { get; set; }

        public Context() {}
        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .Property(p => p.Name)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
