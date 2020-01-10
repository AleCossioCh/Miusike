using Microsoft.EntityFrameworkCore;
using ProyectoMiusike.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMiusike.Data
{
    public class WindAppDBContext : DbContext
    {

        public WindAppDBContext(DbContextOptions<WindAppDBContext> wind)
            : base(wind)

        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArtistaEntity>().ToTable("Artistas");
            modelBuilder.Entity<ArtistaEntity>().HasMany(a => a.Canciones).WithOne(b => b.Artista);
            modelBuilder.Entity<ArtistaEntity>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CacionEntity>().ToTable("Caciones");
            modelBuilder.Entity<CacionEntity>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CacionEntity>().HasOne(b => b.Artista).WithMany(a => a.Canciones);
        }

        public DbSet<ArtistaEntity> Artistas { get; set; }
        public DbSet<CacionEntity> Cansiones { get; set; }
    
    }
}
