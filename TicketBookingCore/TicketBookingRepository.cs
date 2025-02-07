using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingCore
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        private readonly List<TicketBooking> _bookings = new List<TicketBooking>();
        
        public void Save(TicketBooking booking)
        {
            _bookings.Add(booking);
        }

        public void Remove(int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                _bookings.Remove(booking);
            }
        }
    }
}
