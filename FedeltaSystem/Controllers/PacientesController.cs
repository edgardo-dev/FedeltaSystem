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
    public class PacientesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(t => t.Responsable);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacientes tblPacientes = db.Pacientes.Find(id);
            if (tblPacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Consultas = db.Consultas.Where(h => h.IdPaciente == id).ToList();
            return View(tblPacientes);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.IdResponsable = new SelectList(db.Responsables, "IdResponsable", "NombreResponsable");
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,NombrePaciente,Edad,Sexo,Raza,Especie,IdResponsable")] tblPacientes tblPacientes, string Sexo, string Especie)
        {
            if (ModelState.IsValid)
            {
                tblPacientes.Sexo = Sexo;
                tblPacientes.Especie = Especie;
                db.Pacientes.Add(tblPacientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdResponsable = new SelectList(db.Responsables, "IdResponsable", "NombreResponsable", tblPacientes.IdResponsable);
            return View(tblPacientes);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacientes tblPacientes = db.Pacientes.Find(id);
            if (tblPacientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdResponsable = new SelectList(db.Responsables, "IdResponsable", "NombreResponsable", tblPacientes.IdResponsable);
            return View(tblPacientes);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,NombrePaciente,Edad,Sexo,Raza,Especie,IdResponsable")] tblPacientes tblPacientes, string Sexo, string Especie)
        {
            if (ModelState.IsValid)
            {
                tblPacientes.Sexo = Sexo;
                tblPacientes.Especie = Especie;
                db.Entry(tblPacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdResponsable = new SelectList(db.Responsables, "IdResponsable", "NombreResponsable", tblPacientes.IdResponsable);
            return View(tblPacientes);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPacientes tblPacientes = db.Pacientes.Find(id);
            if (tblPacientes == null)
            {
                return HttpNotFound();
            }
            return View(tblPacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPacientes tblPacientes = db.Pacientes.Find(id);
            db.Pacientes.Remove(tblPacientes);
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
