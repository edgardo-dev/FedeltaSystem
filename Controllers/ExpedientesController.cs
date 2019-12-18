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
    public class ExpedientesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Expedientes
        public ActionResult Index()
        {
            var expedientes = db.Expedientes.Include(t => t.Paciente);
            return View(expedientes.ToList());
        }

        // GET: Expedientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpedientes tblExpedientes = db.Expedientes.Find(id);
            if (tblExpedientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Consultas = db.Consultas.Where(h => h.IdPaciente == id).ToList();
            return View(tblExpedientes);
        }

        // GET: Expedientes/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente");
            return View();
        }

        // POST: Expedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExpediente,NumExpediente,FechaCreacion,IdPaciente")] tblExpedientes tblExpedientes)
        {
            if (ModelState.IsValid)
            {
                db.Expedientes.Add(tblExpedientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblExpedientes.IdPaciente);
            return View(tblExpedientes);
        }

        // GET: Expedientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpedientes tblExpedientes = db.Expedientes.Find(id);
            if (tblExpedientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblExpedientes.IdPaciente);
            return View(tblExpedientes);
        }

        // POST: Expedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExpediente,NumExpediente,FechaCreacion,IdPaciente")] tblExpedientes tblExpedientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblExpedientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "IdPaciente", "NombrePaciente", tblExpedientes.IdPaciente);
            return View(tblExpedientes);
        }

        // GET: Expedientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblExpedientes tblExpedientes = db.Expedientes.Find(id);
            if (tblExpedientes == null)
            {
                return HttpNotFound();
            }
            return View(tblExpedientes);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblExpedientes tblExpedientes = db.Expedientes.Find(id);
            db.Expedientes.Remove(tblExpedientes);
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
