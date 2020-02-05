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
    public class CitasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Citas
        public ActionResult Index()
        {
            return View(db.Citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCitas tblCitas = db.Citas.Find(id);
            if (tblCitas == null)
            {
                return HttpNotFound();
            }
            return View(tblCitas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCita,Fecha,Descripcion,Estado,Paciente")] tblCitas tblCitas,string Motivo)
        {
            if (ModelState.IsValid)
            {
                tblCitas.Descripcion = Motivo;
                tblCitas.Estado = "Citado";
                db.Citas.Add(tblCitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCitas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCitas tblCitas = db.Citas.Find(id);
            if (tblCitas == null)
            {
                return HttpNotFound();
            }
            return View(tblCitas);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCita,Fecha,Descripcion,Estado,Paciente")] tblCitas tblCitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCitas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCitas tblCitas = db.Citas.Find(id);
            if (tblCitas == null)
            {
                return HttpNotFound();
            }
            return View(tblCitas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCitas tblCitas = db.Citas.Find(id);
            db.Citas.Remove(tblCitas);
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
