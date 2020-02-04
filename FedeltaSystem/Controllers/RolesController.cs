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
    public class RolesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Roles
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
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
            tblRoles tblRoles = db.Roles.Find(id);
            if (tblRoles == null)
            {
                return HttpNotFound();
            }
            return View(tblRoles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol,Rol,Descripcion")] tblRoles tblRoles)
        {

            if (ModelState.IsValid)
            {
                db.Roles.Add(tblRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRoles);
        }

        // GET: Roles/Edit/5
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
            tblRoles tblRoles = db.Roles.Find(id);
            if (tblRoles == null)
            {
                return HttpNotFound();
            }
            return View(tblRoles);
        }

        // POST: Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol,Rol,Descripcion")] tblRoles tblRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRoles);
        }

        // GET: Roles/Delete/5
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
            tblRoles tblRoles = db.Roles.Find(id);
            if (tblRoles == null)
            {
                return HttpNotFound();
            }
            return View(tblRoles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRoles tblRoles = db.Roles.Find(id);
            db.Roles.Remove(tblRoles);
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
