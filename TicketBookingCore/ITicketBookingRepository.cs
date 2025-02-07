namespace TicketBookingCore
{
    public interface ITicketBookingRepository
    {
        void Save(TicketBooking booking);
        void Remove(int bookingId); 
    }
}