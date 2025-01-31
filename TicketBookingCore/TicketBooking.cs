
namespace TicketBookingCore
{
    public class TicketBooking
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    }
}
