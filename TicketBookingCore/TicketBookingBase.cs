using Microsoft.EntityFrameworkCore;

namespace TicketBookingCore
{
    public class TicketBookingBase : DbContext
    {   // Base class for ticket booking

        public DbSet<TicketBooking> TicketBooking { get; set; }

        public TicketBookingBase(DbContextOptions<TicketBookingBase> options)
            : base(options) { }
    }
}
