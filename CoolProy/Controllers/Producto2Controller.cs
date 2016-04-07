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
    public class Producto2Controller : Controller
    {
        //
        // GET: /Producto2/

        CoolEntities db = new CoolEntities();
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion");
            return PartialView(); 
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {

            var list = db.Producto;

            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges(); 

            }
            producto.Marca = db.Marca.FirstOrDefault(m => m.idmarca == producto.idmarca);
            producto.Modelo = db.Modelo.FirstOrDefault(m => m.idmodelo == producto.idmodelo); 
            return PartialView("_Producto",list.ToList());
            //return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var producto = db.Producto.Find(id);
            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
            ViewBag.idmodelo = new SelectList(db.Modelo, "idmodelo", "descripcion");
            return PartialView(producto);
        }
        [HttpPost]
        public ActionResult Edit(Producto producto,int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
            }
            producto.Marca = db.Marca.FirstOrDefault(m => m.idmarca == producto.idmarca);
            producto.Modelo = db.Modelo.FirstOrDefault(m => m.idmodelo == producto.idmodelo); 
            return PartialView("_Producto",db.Producto.ToList());
        }
         
        public ActionResult Delete(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return PartialView("_Producto",db.Producto.ToList());
        }

    }
}