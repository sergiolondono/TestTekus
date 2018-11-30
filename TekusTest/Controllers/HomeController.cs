using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekusTest.Models;

namespace TekusTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var cliente = _context.Clientes.ToList();
            List<SelectListItem> clientList = new List<SelectListItem>();
            clientList.Clear();
            clientList.Add(new SelectListItem { Text = "-- Seleccionar Cliente --", Value = "" });
            foreach (var row in cliente)
                clientList.Add(new SelectListItem { Text = Convert.ToString(row.Nombre), Value = Convert.ToString(row.Id) });

            ViewBag.cliente = clientList;
            return View();
        }

        [HttpPost]
        public JsonResult getService(int id)
        {
            var servicios = _context.Clientes.FirstOrDefault(cl => cl.Id == id).Servicios.ToList();

            List<SelectListItem> serviceList = new List<SelectListItem>();

            foreach (var item in servicios)
                serviceList.Add(new SelectListItem { Text = Convert.ToString(item.Nombre), Value = Convert.ToString(item.Id) });

            return Json(new SelectList(serviceList, "Value", "Text", JsonRequestBehavior.AllowGet));

        }
    }
}