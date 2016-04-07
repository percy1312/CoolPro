using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

using CoolProy.Models;

namespace CoolProy.Controllers
{
    public class EmpleadoController : Controller
    {
        private CoolEntities db = new CoolEntities();

        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            var empleados = from e in db.Empleado
                           select e;
            ViewBag.empleados = empleados.ToList();
            return View();
        }

     

        public ActionResult Details(int id = 0)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //
        // GET: /Empleado/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Empleado/Create

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }
         
        public ActionResult Edit(int id = 0)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }
         

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }
         
        public ActionResult Delete(int id = 0)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }
         

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tecnicos()
        {
            var empleados = db.Empleado.ToList();
            return View(empleados);
        }

        public ActionResult Modelos()
        {

            var modelos = db.Modelo.ToList();

            return View(modelos);
        }


        public JsonResult GetTecnicos()
        {
            var empleados = db.Empleado.ToList();
         
            return Json(empleados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductos()
        {
            var productos = from p in db.Producto 
                             
                            select p;

            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModelos()
        {
            var modelos = db.Modelo.ToList();

            return Json(modelos, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult AddTecnico(Empleado empleado)
        {



            db.Empleado.Add(empleado);
            db.SaveChanges(); 

            return Json("Cliente almacenado", JsonRequestBehavior.DenyGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}