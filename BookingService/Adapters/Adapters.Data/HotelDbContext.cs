using Adapters.Data.Guest;
using Adapters.Data.Room;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }
        public virtual DbSet<Domain.Entities.Guest> Guests { get; set; }
        public virtual DbSet<Domain.Entities.Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
