using FlyingDutchmanAirlines.DatabaseLayer.Models;
using FlyingDutchmanAirlines.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingDutchmanAirlines.RepositoryLayer
{
    public class AirportRepository
    {
        private readonly FlyingDutchmanAirlinesContext _context;

        public AirportRepository(FlyingDutchmanAirlinesContext context)
        {
            _context = context;
        }
        public AirportRepository()
        {

        }
        public virtual async Task<Airport> GetAirportByID(int airportID)
        {
            if (airportID < 0)
            {
                Console.WriteLine($"Argument Exception in GetAirportByID! AirportID = { airportID}");
                throw new ArgumentException("invalid argument provided");
            }

            return await _context.Airports.FirstOrDefaultAsync(a => a.AirportId == airportID)
                ?? throw new AirportNotFoundException();
        }
    }
}
