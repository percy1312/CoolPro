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
    public class SolicitudInspController : Controller
    {
        private CoolEntities db = new CoolEntities();

        //
        // GET: /SolicitudInsp/

        public ActionResult Index()
        {
            var solicitudes = from e in db.SolicitudInspeccion
                          select e;

            ViewBag.ocultarCategorias = false;
            ViewBag.solicitudes = solicitudes.ToList();
            return View();     
        }

        public ActionResult BuscarCliente(string CadenaBusqueda)
        {
            var data = from c in db.Cliente select c;
            if (!String.IsNullOrEmpty(CadenaBusqueda))
            {
                data = data.Where(s => s.nombre.ToUpper().Contains(CadenaBusqueda.ToUpper()));
            }
            return View(data.ToList());
        }

        //
        // GET: /SolicitudInsp/Details/5

        public ActionResult Details(int id = 0)
        {
            SolicitudInspeccion solicitudinspeccion = db.SolicitudInspeccion.Find(id);
            if (solicitudinspeccion == null)
            {
                return HttpNotFound();
            }
            return View(solicitudinspeccion);
        }



     

        public ActionResult Create( )  
        {

         
             

            IEnumerable<Cliente> clientes = db.Cliente.ToList();
            SolicitudInspeccion c = new SolicitudInspeccion();

            Encap m = new Encap();
            m.mdl1 = c;
            m.mdl2 = clientes;

            //Cliente cliente = db.Cliente.Find(id);

            var cli = from ce in db.Cliente 
                      select ce;

            

            ViewBag.clientes = clientes;
            ViewBag.idcliente = new SelectList(db.Cliente, "idcliente", "nombre");
            return View(m);
        }

        //
        // POST: /SolicitudInsp/Create

        [HttpPost]
        public ActionResult Create(SolicitudInspeccion solicitudinspeccion)
        {

            IEnumerable<Cliente> clientes = db.Cliente.ToList();
            SolicitudInspeccion c = new SolicitudInspeccion();

            Encap m = new Encap();
            m.mdl1 = c;
            m.mdl2 = clientes;
            if (ModelState.IsValid)
            {
                db.Entry(solicitudinspeccion).State = EntityState.Modified;


                db.SolicitudInspeccion.Add(solicitudinspeccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           

            ViewBag.idcliente = new SelectList(db.Cliente, "idcliente", "nombre", solicitudinspeccion.idcliente);
            return View(m);
        }

        //
        // GET: /SolicitudInsp/Edit/5

        public ActionResult Edit(int id = 0)
        {
            
             SolicitudInspeccion s = db.SolicitudInspeccion.Find(id);
             Encap mod = new Encap();
             mod.solicitudinspeccion = s;


            //SolicitudInspeccion solicitudinspeccion = db.SolicitudInspeccion.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcliente = new SelectList(db.Cliente, "idcliente", "nombre", s.idcliente);
            return View(mod);
        }

        //
        // POST: /SolicitudInsp/Edit/5

        [HttpPost]
        public ActionResult Edit(SolicitudInspeccion solicitudinspeccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudinspeccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcliente = new SelectList(db.Cliente, "idcliente", "nombre", solicitudinspeccion.idcliente);
            return View(solicitudinspeccion);
        }

        //
        // GET: /SolicitudInsp/Delete/5

       

        public JsonResult GetClientes(){

            var clientes = db.Cliente.ToList();
            return Json(clientes, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Delete(int id = 0)
        {
            SolicitudInspeccion solicitudinspeccion = db.SolicitudInspeccion.Find(id);
            Encap mod = new Encap();
            mod.solicitudinspeccion = solicitudinspeccion;
            if (solicitudinspeccion == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        //
        // POST: /SolicitudInsp/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudInspeccion solicitudinspeccion = db.SolicitudInspeccion.Find(id);
            db.SolicitudInspeccion.Remove(solicitudinspeccion);
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