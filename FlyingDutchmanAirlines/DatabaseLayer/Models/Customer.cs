using System;
using System.Collections.Generic;

#nullable disable

namespace FlyingDutchmanAirlines.DatabaseLayer.Models
{
    public sealed class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Bookings = new HashSet<Booking>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public static bool Equals(Customer x, Customer y)
        {
            return x.CustomerId == y.CustomerId && x.Name == y.Name;
        }
    }
}