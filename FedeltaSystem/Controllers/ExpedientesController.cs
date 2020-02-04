using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FedeltaSystem.Models;
using Rotativa;

namespace FedeltaSystem.Controllers
{
    public class ExpedientesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Expedientes
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var expedientes = db.Expedientes.Include(t => t.Paciente);
            return View(expedientes.ToList());
        }
        [HttpGet]
        public ActionResult CargarPaciente()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Responsables = db.Responsables;
            return View();
        }
        [HttpPost]
        public ActionResult CargarPaciente(int NumExpediente, int IdResponsable, string NombrePaciente,
            int Edad, string Sexo, string Raza, string Especie)
        {
            try
            {
                var Pacientes = new tblPacientes();

                Pacientes.NombrePaciente = NombrePaciente;
                Pacientes.Edad = Edad;
                Pacientes.Sexo = Sexo;
                Pacientes.Raza = Raza;
                Pacientes.Especie = Especie;
                Pacientes.IdResponsable = IdResponsable;
                db.Pacientes.Add(Pacientes);
                db.SaveChanges();
                using (var db2 = new Contexto())
                {
                    var Expedientes = new tblExpedientes();
                    Expedientes.NumExpediente = NumExpediente;
                    Expedientes.FechaCreacion = DateTime.Now;
                    var idPaciente = (from id in db2.Pacientes select id.IdPaciente).Max();
                    Expedientes.IdPaciente = idPaciente;
                    db2.Expedientes.Add(Expedientes);
                    db2.SaveChanges();
                }

                return RedirectToAction("Index", "Pacientes");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Expedientes/Details/5
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
            tblExpedientes tblExpedientes = db.Expedientes.Find(id);
            if (tblExpedientes == null)
            {
                return HttpNotFound();
            }

            ViewBag.Consultas = db.Consultas.Where(h => h.IdPaciente == id).ToList();
            return View(tblExpedientes);
        }
        // GET: Expedientes/Edit/5
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
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
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
        public ActionResult ReporteExpediente(int? id)
        {
            ViewBag.Consultas = db.Consultas.Where(c => c.IdPaciente == id).ToList();
            ViewBag.Expediente = db.Expedientes.Where(e => e.IdPaciente == id).FirstOrDefault();
            ViewBag.Paciente = db.Pacientes.Where(p => p.IdPaciente == id).Include(r => r.Responsable).FirstOrDefault();
           
            return View();
        }
        public ActionResult Print(int id)
        {
            return new ActionAsPdf("ReporteExpediente", new {id = id})
            { FileName = "Reporte_Expediente.pdf" };
        } 
            

    }
}
