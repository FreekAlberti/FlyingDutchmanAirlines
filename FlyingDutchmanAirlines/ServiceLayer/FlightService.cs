using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.RepositoryLayer;
using FlyingDutchmanAirlines.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingDutchmanAirlines.ServiceLayer
{
    public class FlightService
    {
        private readonly AirportRepository _airportRepository;
        private readonly FlightRepository _flightRepository;
        public FlightService(AirportRepository airportRepository,
            FlightRepository flightRepository)
        {
            _airportRepository = airportRepository;
            _flightRepository = flightRepository;
        }
        public async IAsyncEnumerable<FlightView> GetFlights()
        {
            Queue<Flight> flights = _flightRepository.GetFlights();
            foreach (Flight flight in flights)
            {
                Airport originAirport = await _airportRepository.GetAirportByID(flight.Origin);
                Airport destinationAirport = await _airportRepository.GetAirportByID(flight.Destination);
                yield return new FlightView(flight.FlightNumber.ToString(), (originAirport.City, originAirport.Iata), (destinationAirport.City, destinationAirport.Iata));
            }
        }
    }
}
