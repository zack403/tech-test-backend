using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechTestBackend.Domain.Entities;

namespace TechTestBackend.DataAccess
{
    public class TechTestBackendContext : DbContext
    {
        public TechTestBackendContext(DbContextOptions<TechTestBackendContext> options) : base(options)
        {
        }

        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Payment>().Property(x => x.CreditCardNumber)
                .IsRequired();
            modelbuilder.Entity<Payment>().Property(x => x.CardHolder)
                .IsRequired();
            modelbuilder.Entity<Payment>().Property(x => x.ExpirationDate)
                .IsRequired();
            modelbuilder.Entity<Payment>().Property(x => x.ExpirationDate)
                .IsRequired();
            modelbuilder.Entity<Payment>().Property(x => x.SecurityCode)
                .IsRequired(false)
                .HasMaxLength(3);
            modelbuilder.Entity<Payment>().Property(x => x.Amount)
                .IsRequired();

            // entity index definition
            modelbuilder.Entity<Payment>().HasIndex(x => x.Id)
                .IsUnique(false);
            modelbuilder.Entity<Payment>().HasIndex(x => x.State)
                .IsUnique(false);
           
        }
    }
}
