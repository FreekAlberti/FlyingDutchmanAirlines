using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class BookingRepository
    {
        private readonly FlyingDutchmanAirlinesContext _context;

        public BookingRepository(FlyingDutchmanAirlinesContext context)
        {
            _context = context;
        }
        public BookingRepository()
        {

        }
        public virtual async Task CreateBooking(int customerId, int flightNumber)
        {
            if (!customerId.IsPositive() || !flightNumber.IsPositive())
            {
                Console.WriteLine($"Argument Exception in CreateBooking! CustomerID = {customerId}, FlightNumber = {flightNumber}");
                throw new ArgumentException("Invalid arguments provided");
            }
            Booking newBooking = new(customerId, flightNumber)
            {
                CustomerId = customerId,
                FlightNumber = flightNumber
            };
            try
            {
                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during database query: { ex.Message}");
                throw new CouldNotAddBookingToDatabaseException();
            }
        }
    }
}