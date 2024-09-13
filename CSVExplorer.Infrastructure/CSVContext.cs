using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using CSVExplorer.Core.Domain.Entities;


namespace CSVExplorer.Infrastructure
{
    public class CSVContext : DbContext
    {
        public CSVContext(DbContextOptions<CSVContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("birth_date");

                entity.Property(e => e.Married)
                    .HasColumnName("is_married");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Salary)
                    .HasColumnName("current_salary")
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });
        }
    }
}