using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApiLab.Models
{
    public partial class IF4101_A95777_2020Context : DbContext
    {
        public IF4101_A95777_2020Context()
        {
        }

        public IF4101_A95777_2020Context(DbContextOptions<IF4101_A95777_2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Interests)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Seniority)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MajorNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Major)
                    .HasConstraintName("Major_fk");

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Nationality)
                    .HasConstraintName("Nationality_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
