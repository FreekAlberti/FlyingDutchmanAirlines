using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;
using FlyingDutchmanAirlines.RepositoryLayer;
using FlyingDutchmanAirlines.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace FlyingDutchmanAirlines_Tests.ServiceLayer
{
    [TestClass]
    public class BookingServiceTests
    {
        private Mock<BookingRepository> _mockBookingRepository;
        private Mock<FlightRepository> _mockFlightRepository;
        private Mock<CustomerRepository> _mockCustomerRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockBookingRepository = new Mock<BookingRepository>();
            _mockFlightRepository = new Mock<FlightRepository>();
            _mockCustomerRepository = new Mock<CustomerRepository>();
        }

        [TestMethod]
        public async Task CreateBooking_Success()
        {
            _mockBookingRepository.Setup(repository => repository.CreateBooking(0, 0)).Returns(Task.CompletedTask);
            _mockCustomerRepository.Setup(repository => repository.GetCustomerByName("Leo Tolstoy"))
                .Returns(Task.FromResult(new Customer("Leo Tolstoy")));
            _mockFlightRepository.Setup(repository => repository.GetFlightByFlightNumber(0))
                .Returns(Task.FromResult(new Flight()));

            BookingService service = new BookingService(_mockBookingRepository.Object, _mockFlightRepository.Object, _mockCustomerRepository.Object);

            (bool result, Exception exception) = await service.CreateBooking("Leo Tolstoy", 0);

            Assert.IsTrue(result);
            Assert.IsNull(exception);
        }
    }
}
