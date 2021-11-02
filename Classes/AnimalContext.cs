using System;
using System.Collections.Generic;
using Animal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Animal.Classes
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<TypeAnimal> Types { get; set; }

        public string DbPath { get; private set; }

        public AnimalContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Animal.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one blog has many post
            modelBuilder.Entity<Food>()
                .HasOne(p => p.Animal)
                .WithMany(b => b.Foods);

            modelBuilder.Entity<Animal>()
                .Property(b => b.Name)
                .HasMaxLength(20) // maximum length
                .IsRequired();
        }
    }
}