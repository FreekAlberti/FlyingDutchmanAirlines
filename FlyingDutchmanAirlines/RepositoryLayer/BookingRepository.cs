﻿using FlyingDutchmanAirlines.DatabaseLayer.Models;
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
        public async Task CreateBooking(int customerId, int flightNumber)
        {
            if (customerId < 0 || flightNumber < 0)
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
            catch (Exception exception)
            {
                Console.WriteLine($"Exception during database query: { exception.Message}");
                throw new CouldNotAddBookingToDatabaseException();
            }
            // 192*************************************
        }
    }
}