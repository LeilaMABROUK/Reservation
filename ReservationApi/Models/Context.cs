using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationApi.Models;

namespace ReservationApi.Models
{
    public class Context : DbContext

    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Terrain> Terrains { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
        .HasKey(bc => new { bc.IdClient, bc.IdTerrain });
            modelBuilder.Entity<Reservation>()
                .HasOne(bc => bc.client)
                .WithMany(b => b.Reservations)
                .HasForeignKey(bc => bc.IdClient);
            modelBuilder.Entity<Reservation>()
                .HasOne(bc => bc.terrain)
                .WithMany(c => c.Reservations)
                .HasForeignKey(bc => bc.IdTerrain);

            modelBuilder.Entity<Club>()
                .HasMany(c =>c.Terrains)
                .WithOne(t=>t.club)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<ReservationApi.Models.Reservation> Reservation { get; set; }

    }

}
