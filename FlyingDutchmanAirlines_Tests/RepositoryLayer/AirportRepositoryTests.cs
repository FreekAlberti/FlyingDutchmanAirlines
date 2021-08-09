using FlyingDutchmanAirlines;
using FlyingDutchmanAirlines_Tests.Stubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyingDutchmanAirlines.RepositoryLayer;
using FlyingDutchmanAirlines.DatabaseLayer.Models;

namespace FlyingDutchmanAirlines_Tests.RepositoryLayer
{
    [TestClass]
    public class AirportRepositoryTests
    {
        private FlyingDutchmanAirlinesContext _context;
        private AirportRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            DbContextOptions<FlyingDutchmanAirlinesContext> dbContextOptions = new DbContextOptionsBuilder<FlyingDutchmanAirlinesContext>()
                .UseInMemoryDatabase("FlyingDutchman")
                .Options;
            _context = new FlyingDutchmanAirlinesContext_Stub(dbContextOptions);
            _repository = new AirportRepository(_context);
            Assert.IsNotNull(_repository);
        }
        [TestMethod]
        public async Task GetAirportByID_Success()
        {
            Airport airport = await _repository.GetAirportByID(0);
            Assert.IsNotNull(airport);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetAirportByID_Failure_InvalidInput()
        {
            await _repository.GetAirportByID(-1);
        }
    }
}
