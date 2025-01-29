namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    { // Class to process ticket booking request
        public TicketBookingRequestProcessor()
        {
            // Constructor
        }

        public TicketBookingResponse Book(TicketBookingRequest? request)
        {
            // Check if request is null
            ArgumentNullException.ThrowIfNull(request);

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