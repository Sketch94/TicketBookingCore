﻿using Moq;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingRepository> _ticketBookingRepositoryMock;
        private readonly TicketBookingRequestProcessor _processor;
        public TicketBookingRequestProcessorTests()
        {
            _request = new TicketBookingRequest
            {
                FirstName = "Armend",
                LastName = "Berisha",
                Email = "Armend@outlook.com"
            };
            _ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_ticketBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnTicketBookningResultWithRequestValues()
        {
            // Arrange

            var request = new TicketBookingRequest
            {
                FirstName = "Armend",
                LastName = "Berisha",
                Email = "Armend@outlook.com"
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
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null!));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }

        /// <summary>
        /// This test will fail because the method is not implemented yet.
        /// </summary>
        [Fact]
        public void ShouldSaveToDatabase()
        {
            // Arrange
            TicketBooking savedTicketBooking = null!;

            // Setup the Save method to capture the saved ticket booking
            _ticketBookingRepositoryMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
            .Callback<TicketBooking>((ticketBooking) =>
            {
                savedTicketBooking = ticketBooking;
            });

            var request = new TicketBookingRequest
            {
                FirstName = "Armend",
                LastName = "Berisha",
                Email = "Armend@outlook.com"
            };


            // Act
            _processor.Book(_request);

            // Assert

            /// Verify that the Save method was called once
            _ticketBookingRepositoryMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

            Assert.NotNull(savedTicketBooking);
            Assert.Equal(_request.FirstName, savedTicketBooking.FirstName);
            Assert.Equal(_request.LastName, savedTicketBooking.LastName);
            Assert.Equal(_request.Email, savedTicketBooking.Email);

            // Testing in vs powershell if the code works. 
            Console.WriteLine($"Passenger: {savedTicketBooking.Id}\n" +
                              $"Firstname: {savedTicketBooking.FirstName}\n" +
                              $"Lastname: {savedTicketBooking.LastName}\n" +
                              $"Email: {savedTicketBooking.Email}");

        }
    }
}