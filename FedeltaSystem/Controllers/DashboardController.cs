using FedeltaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedeltaSystem.Controllers
{
    public class DashboardController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Dashboard
        public ActionResult Index()
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            ViewBag.CR = db.Responsables.Count();
            ViewBag.CP = db.Pacientes.Count();
            ViewBag.CU = db.Usuarios.Count();
            ViewBag.CC = db.Consultas.Count();
            ViewBag.CE = db.Expedientes.Count();
            ViewBag.CEE = db.Expedientes.Count();

            return View();
        }
    }
}