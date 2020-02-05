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
        public Contexto db = new Contexto();
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index","Login");
            }
            
            ViewBag.CR = db.Responsables.Count();
            ViewBag.CP = db.Pacientes.Count();
            ViewBag.CU = db.Usuarios.Count();
            ViewBag.CR = db.Roles.Count();
            ViewBag.CC = db.Consultas.Count();
            ViewBag.CE = db.Empleados.Count();
            //ViewBag.CV = db.Vacunas.Count();
            ViewBag.CEE = db.Expedientes.Count();
            ViewBag.Citas = db.Citas.Where(C => C.Estado == "Citado").Count();

            return View();
        }
    }
}