using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Core;

namespace TekusTest.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Countries
        public ActionResult Index()
        {
            fillCountriesServices();
            return View();
        }

        private void fillCountriesServices()
        {
            var countries = _unitOfWork.Countries.getCountries();
            List<SelectListItem> countriesList = new List<SelectListItem>();
            countriesList.Clear();

            countriesList.Add(new SelectListItem { Text = "-- Seleccionar Pais --", Value = "" });
            foreach (var row in countries)
                countriesList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.paises = countriesList;
        }
    }
}