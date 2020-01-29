using FedeltaSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FedeltaSystem.Controllers
{
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Usuarios
        public ActionResult Index()
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            var usuarios = db.Usuarios.Include(t => t.Empleados).Include(t => t.Roles);
            return View(usuarios.ToList());
        }
        public ActionResult Create()
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado");
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
               
                db.Usuarios.Add(tblUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }
        public ActionResult Details(int? id)
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }
        public ActionResult Edit(int? id)
        {
            //if (Session["IdUsuario"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(tblUsuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string Encriptar(string Pass)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Byte[] Hash, InsertarByte;
            InsertarByte = (new UnicodeEncoding()).GetBytes(Pass);
            Hash = sha1.ComputeHash(InsertarByte);
            return Convert.ToBase64String(Hash);
        }

    }
}