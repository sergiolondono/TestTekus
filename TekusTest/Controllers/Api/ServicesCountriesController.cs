using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TekusTest.Core;
using TekusTest.Models;

namespace TekusTest.Controllers.Api
{
    public class ServicesCountriesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesCountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PaisesPorServicio> getCountriesServices()
        {
            return _unitOfWork.CountriesServices.getCountriesServices();
        }

        public PaisesPorServicio getCountryServiceById(int id)
        {
            return _unitOfWork.CountriesServices.getCountryServcieById(id);
        }

        [HttpPost]
        public PaisesPorServicio createCountryService(PaisesPorServicio paisServicio)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (_unitOfWork.CountriesServices.getCountryServiceExist(paisServicio.IdServicio, paisServicio.IdPais).Any())
                throw new HttpResponseException(HttpStatusCode.Conflict);

            _unitOfWork.CountriesServices.Create(paisServicio);
            _unitOfWork.Complete();

            return paisServicio;
        }

        [HttpPut]
        public IHttpActionResult updateCountryService(int id, PaisesPorServicio paisServicio)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var countryServiceInDb = _unitOfWork.CountriesServices.getCountryServcieById(id);
            if (countryServiceInDb != null)
            {
                countryServiceInDb.IdPais = paisServicio.IdPais;
                countryServiceInDb.IdServicio = paisServicio.IdServicio;

                _unitOfWork.Complete();

                return Ok(countryServiceInDb);
            }
            else
                return BadRequest();
        }
    }
}

