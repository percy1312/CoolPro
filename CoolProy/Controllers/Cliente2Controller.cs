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
    public class Cliente2Controller : Controller
    {
        private CoolEntities db = new CoolEntities();

        //
        // GET: /Cliente2/

        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente2/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente2/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();

                Session["mensaje2"] = "Se egistro correctamente";
                return RedirectToAction("Create", "SolicitudInsp");
                //return RedirectToAction("Index", "Cliente2");
            }

            return View(cliente);
        }

        //
        // GET: /Cliente2/Edit/5

        public ActionResult Edit(int id = 0)
        {
          var cliente = db.Cliente.Find(id);
            
            return PartialView(cliente);
        } 

        //
        // POST: /Cliente2/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente ,int id)
        {
          
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges(); 
            }
            return PartialView("_Cliente",db.Cliente.ToList());
        }
         

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return PartialView("_Cliente", db.Cliente.ToList());
        }

         
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}