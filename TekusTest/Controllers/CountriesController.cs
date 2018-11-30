using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Models;

namespace TekusTest.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Countries
        public ActionResult Index()
        {
            fillCountriesServices();
            return View();
        }

        private void fillCountriesServices()
        {
            var countries = _context.Paises.ToList();
            List<SelectListItem> countriesList = new List<SelectListItem>();
            countriesList.Clear();

            countriesList.Add(new SelectListItem { Text = "-- Seleccionar Pais --", Value = "" });
            foreach (var row in countries)
                countriesList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.paises = countriesList;
        }
    }
}