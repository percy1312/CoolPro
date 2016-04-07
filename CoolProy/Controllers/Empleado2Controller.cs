using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolProy.Models;

namespace CoolProy.Controllers
{
    public class Empleado2Controller : Controller
    {
        private CoolEntities db = new CoolEntities();

        //
        // GET: /Empleado2/

        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        //
        // GET: /Empleado2/Details/5

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
        // GET: /Empleado2/Create

        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // POST: /Empleado2/Create

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges(); 
            }

            return PartialView("_Empleado", db.Empleado.ToList());
        }

        //
        // GET: /Empleado2/Edit/5

        public ActionResult Edit(int  id )
        {
            var empleado = db.Empleado.Find(id);
            
            return PartialView(empleado);
        }

        //
        // POST: /Empleado2/Edit/5

        [HttpPost]
        public ActionResult Edit(Empleado empleado,int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges(); 
            }
            return PartialView("_Empleado",db.Empleado.ToList());
        }

          
        public ActionResult Delete(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return PartialView("_Empleado",db.Empleado.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}