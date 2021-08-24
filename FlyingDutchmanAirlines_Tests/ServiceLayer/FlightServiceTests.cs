using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.RepositoryLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingDutchmanAirlines_Tests.ServiceLayer
{
    [TestClass]
    public class FlightServiceTests
    {
        private Mock<AirportRepository> _mockAirportRepository;
        private Mock<FlightRepository> _mockFlightRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockAirportRepository = new Mock<AirportRepository>();
            _mockFlightRepository = new Mock<FlightRepository>();
        }
        [TestMethod]
        public async Task GetFlights_Success()
        {
            Flight flightInDatabase = new Flight
            {
                FlightNumber = 148,
                Origin = 31,
                Destination = 92
            };
            Queue<Flight> mockReturn = new Queue<Flight>(1);
            mockReturn.Enqueue(flightInDatabase);
            _mockFlightRepository.Setup(repository => repository.GetFlights()).Returns(mockReturn);
            _mockAirportRepository.Setup(repository => repository.GetAirportByID(31)).ReturnsAsync(new Airport
            {
                AirportId = 31,
                City = "Mexico City",
                Iata = "MEX"
            });
            _mockAirportRepository.Setup(repository => repository.GetAirportByID(92)).ReturnsAsync(new Airport
            {
                AirportId = 92,
                City = "Ulaanbaataar",
                Iata = "UBN"
            });
        }
    }
}
