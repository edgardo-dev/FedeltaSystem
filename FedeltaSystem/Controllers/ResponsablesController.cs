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
    public class ResponsablesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Responsables
        public ActionResult Index()
        {
            return View(db.Responsables.ToList());
        }

        // GET: Responsables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResponsables tblResponsables = db.Responsables.Find(id);
            if (tblResponsables == null)
            {
                return HttpNotFound();
            }
            return View(tblResponsables);
        }

        // GET: Responsables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResponsable,NombreResponsable,ApellidoResponsable,Direccion,Telefono")] tblResponsables tblResponsables)
        {
            if (ModelState.IsValid)
            {
                db.Responsables.Add(tblResponsables);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblResponsables);
        }

        // GET: Responsables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResponsables tblResponsables = db.Responsables.Find(id);
            if (tblResponsables == null)
            {
                return HttpNotFound();
            }
            return View(tblResponsables);
        }

        // POST: Responsables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResponsable,NombreResponsable,ApellidoResponsable,Direccion,Telefono")] tblResponsables tblResponsables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblResponsables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblResponsables);
        }

        // GET: Responsables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblResponsables tblResponsables = db.Responsables.Find(id);
            if (tblResponsables == null)
            {
                return HttpNotFound();
            }
            return View(tblResponsables);
        }

        // POST: Responsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblResponsables tblResponsables = db.Responsables.Find(id);
            db.Responsables.Remove(tblResponsables);
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
