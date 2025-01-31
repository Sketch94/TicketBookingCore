namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    { // Class to process ticket booking request
        private readonly TicketBookingBase _dbContext;

        public TicketBookingRequestProcesser(TicketBookingBase dbContext)
        {
            _dbContext = dbContext;
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));

            }

            var booking = new TicketBooking
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _dbContext.TicketBooking.Add(booking);
            _dbContext.SaveChanges();

            return new TicketBookingResponse
            {
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                Email = booking.Email
            };
        }
    }
}