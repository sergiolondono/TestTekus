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
    public class CountriesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Paises> getCountries()
        {
            return _unitOfWork.Countries.getCountries();
        }

        public Paises getcountryById(int id)
        {
            return _unitOfWork.Countries.getCountryById(id);
        }

        [HttpPost]
        public Paises createCountry(Paises pais)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _unitOfWork.Countries.Create(pais);
            _unitOfWork.Complete();

            return pais;
        }

        [HttpPut]
        public IHttpActionResult updateCountry(int id, Paises pais)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var countryInDb = _unitOfWork.Countries.getCountryById(id);
            if (countryInDb != null)
            {
                countryInDb.Nombre = pais.Nombre;

                _unitOfWork.Complete();

                return Ok(countryInDb);
            }
            else
                return BadRequest();
        }
    }
}
