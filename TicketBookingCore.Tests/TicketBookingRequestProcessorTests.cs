using System.Runtime.CompilerServices;

namespace TicketBookingCore.Tests;

public class TicketBookingRequestProcessorTests
{
    private readonly TicketBookingRequestProcessor _processor;

    public TicketBookingRequestProcessorTests()
    {
        _processor = new TicketBookingRequestProcessor();
    }

    // Test method to test the Book method of TicketBookingRequestProcessor
    [Fact]
    public void ShouldReturnTicketBookingResultWithRequestValues()
    {
        // Arrange
        var processor = new TicketBookingRequestProcessor();

        var request = new TicketBookingRequest
        {
            FirstName = "Armend",
            LastName = "Berisha",
            Email = "Armend@demo.com"
        };

        // Act
        TicketBookingResponse response = _processor.Book(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(request.FirstName, response.FirstName);
        Assert.Equal(request.LastName, response.LastName);
        Assert.Equal(request.Email, response.Email);
    }

    [Fact] 
    public void ShouldThrowExceptionWhenRequestIsNull()
    {
        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));
        // Assert
        Assert.Equal("request", exception.ParamName);
    }
}
