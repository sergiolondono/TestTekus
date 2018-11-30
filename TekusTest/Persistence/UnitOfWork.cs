using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TekusTest.Core;
using TekusTest.Core.Repositories;
using TekusTest.Models;
using TekusTest.Repositories;

namespace TekusTest.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IClientRepository Clients { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public IServiceRepository Services { get; private set; }
        public IServiceCountryRepository CountriesServices { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Clients = new ClientRepository(context);
            Countries = new CountryRepository(context);
            Services = new ServiceRepository(context);
            CountriesServices = new ServiceCountryRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}