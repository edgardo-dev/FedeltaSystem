using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FedeltaSystem.Models;

namespace FedeltaSystem.Controllers
{
    public class ConsultasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Consultas
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var consultas = db.Consultas.Include(t => t.Paciente);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConsultas tblConsultas = db.Consultas.Find(id);
            if (tblConsultas == null)
            {
                return HttpNotFound();
            }
            return View(tblConsultas);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente");
            return View();
        }

        // POST: Consultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConsulta,IdPaciente,FechaConsulta,Peso,Temperatura,Diagnostico,Observaciones")] tblConsultas tblConsultas)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(tblConsultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblConsultas.IdPaciente);
            return View(tblConsultas);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConsultas tblConsultas = db.Consultas.Find(id);
            if (tblConsultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblConsultas.IdPaciente);
            return View(tblConsultas);
        }

        // POST: Consultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConsulta,IdPaciente,FechaConsulta,Peso,Temperatura,Diagnostico,Observaciones")] tblConsultas tblConsultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblConsultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblConsultas.IdPaciente);
            return View(tblConsultas);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblConsultas tblConsultas = db.Consultas.Find(id);
            if (tblConsultas == null)
            {
                return HttpNotFound();
            }
            return View(tblConsultas);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblConsultas tblConsultas = db.Consultas.Find(id);
            db.Consultas.Remove(tblConsultas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
