using Domain.Ports;

namespace Adapters.Data.Guest_
{
    public class GuestRepository : IGuestRepository
    {
        private HotelDbContext _hotelDbContext;
        public GuestRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<Domain.Entities.Guest> Get(int id)
        {
            return await _hotelDbContext.Guests.FindAsync(id);
        }

        public async Task<int> Save(Domain.Entities.Guest guest)
        {
            _hotelDbContext.Guests.Add(guest);
            await _hotelDbContext.SaveChangesAsync();
            return guest.Id;
        }
    }
}
