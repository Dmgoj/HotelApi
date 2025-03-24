using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationGuest> ReservationGuests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationGuest>()
                .HasKey(rg => new { rg.ReservationId, rg.GuestId }); // Composite PK

            modelBuilder.Entity<ReservationGuest>()
                .HasOne(rg => rg.Reservation)
                .WithMany(r => r.ReservationGuests)
                .HasForeignKey(rg => rg.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservationGuest>()
                .HasOne(rg => rg.Guest)
                .WithMany(g => g.ReservationGuests)
                .HasForeignKey(rg => rg.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
