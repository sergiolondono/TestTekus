using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Core;

namespace TekusTest.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SummaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Summary
        public ActionResult Index()
        {
            ViewBag.Clientes = _unitOfWork.Clients.getClients().Count();
            ViewBag.Servicios = _unitOfWork.Services.getServices().Count();
            ViewBag.ServiciosxPaises = _unitOfWork.CountriesServices.getServicesByCountry();

            return View();
        }
    }
}