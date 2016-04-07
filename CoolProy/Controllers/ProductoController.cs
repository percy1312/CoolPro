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
    public class ProductoController : Controller
    {
      private CoolEntities db = new CoolEntities();
        // GET: /Producto/

        public ActionResult Index()
        {
            //var producto = db.Producto.Include(i => i.idmarca).Include(i => i.idmodelo);
            //var productos = from e in db.Producto
            //                select e;

            Encap m = new Encap();
            Producto p = new Producto();

            IEnumerable<Producto> productos = from e in db.Producto select e;
            m.mproducto = p;
            m.listpro = productos;

            ViewBag.ocultarCategorias = false;
            //ViewBag.productos = productos.ToList();
            return View(m);
        }

        public ActionResult Create()
        {
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", producto.idmarca);
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion", producto.idmodelo);
            return View(producto);
        }

        public ActionResult Details(int id)
        {
            var producto = (from e in db.Producto
                          where e.idproducto == id
                          select e).FirstOrDefault();
            Encap mod = new Encap();
            mod.mproducto = producto;
            mod.mproducto.descripcion = producto.descripcion;
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion");
            return View(mod);

        }

        public ActionResult Edit(int id = 0)
        {


            var producto = (from e in db.Producto
                          where e.idproducto == id
                          select e).FirstOrDefault();
            Encap mod = new Encap();
            mod.mproducto = producto;
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", producto.idmarca);
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion",producto.idmodelo);
            return View(mod);

        }


        [HttpPost]
        public ActionResult Edit(Producto producto)
        {

            //var equi= (from e in db.Equipo
            //              where e.idequipo == equipo.idequipo
            //              select e).FirstOrDefault();

            Encap mod = new Encap();
            mod.mproducto = producto;
            if (ModelState.IsValid)
            {

                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", mod.mproducto.idmarca);
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion", mod.mproducto.idmodelo);
            return View(mod);


        }

        public ActionResult Delete(int id = 0)
        {

            var producto = (from e in db.Producto
                          where e.idproducto == id
                          select e).FirstOrDefault();
            Encap mod = new Encap();
            mod.mproducto = producto;
            mod.mproducto.descripcion = producto.descripcion;
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion");
            
            return View(mod);


        }

        //
        // POST: /Equipo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
