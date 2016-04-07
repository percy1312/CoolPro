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
    public class ClienteController : Controller
    {
        private CoolEntities db = new CoolEntities();


        public ActionResult BuscarCliente(string CadenaBusqueda)
        {
          var data = from c in db.Cliente select c;
             if (!String.IsNullOrEmpty(CadenaBusqueda)){
                data = data.Where(s => s.nombre.ToUpper().Contains(CadenaBusqueda.ToUpper()));
                }

             ViewBag.clientes = data.ToList();
                return View(data.ToList());
        }

        public ActionResult Index()
        {
            var clientes = from e in db.Cliente
                          select e;

            ViewBag.ocultarCategorias = false;
            ViewBag.clientes = clientes.ToList();
            return View();
            //return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

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
        // GET: /Cliente/Create

        public ActionResult Create()
        { 
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Create","SolicitudInsp");
            }

            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            Encap mod = new Encap();
            mod.cliente = cliente;

            //Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            Encap mod = new Encap();
            mod.cliente = cliente;
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}