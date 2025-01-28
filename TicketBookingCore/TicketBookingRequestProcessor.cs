namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        public TicketBookingRequestProcessor()
        {

        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            // Logic to book ticket
            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}