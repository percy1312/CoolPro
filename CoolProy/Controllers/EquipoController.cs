//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CoolProy.Models;

//namespace CoolProy.Controllers
//{
//    public class EquipoController : Controller
//    {
//        private CoolEntities db = new CoolEntities();

//        //
//        // GET: /Equipo/

//        public ActionResult Index()
//        {
//            var equipos = from e in db.Equipo 
//                          select e;

//            ViewBag.ocultarCategorias = false;
//            ViewBag.equipos = equipos.ToList();
//            return View(); 
//        }
 

//        public ActionResult Create()
//        {
//            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
//            return View();
//        }

     
//        [HttpPost]
//        public ActionResult Create(Equipo equipo)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Equipo.Add(equipo);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", equipo.idmarca);
//            return View(equipo);
//        }

//        public ActionResult Detalle(int id)
//        {
//             var equipo = (from e in db.Equipo
//                          where e.idequipo == id
//                          select e).FirstOrDefault();
//            Modelo mod = new Modelo();
//            mod.equipo = equipo;
//            mod.equipo.descripcion = equipo.descripcion;
//            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
//            return View(mod);
  
//        }


//        public ActionResult Edit(int id = 0)
//        {
            

//            var equipo = (from e in db.Equipo
//                          where e.idequipo == id
//                          select e).FirstOrDefault();
//            Modelo mod = new Modelo();
//            mod.equipo = equipo;
//            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", equipo.idmarca);
//            return View(mod);
          
//        }
         

//        [HttpPost]
//        public ActionResult Edit(Equipo equipo)
//        {
            
//            //var equi= (from e in db.Equipo
//            //              where e.idequipo == equipo.idequipo
//            //              select e).FirstOrDefault();

//            Modelo mod = new Modelo();
//            mod.equipo = equipo;
//            if (ModelState.IsValid)
//            {

//                db.Entry(equipo).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//                ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion", mod.equipo.idmarca);
//                return View(mod);
           
           
//        }

//        //
//        // GET: /Equipo/Delete/5

//        public ActionResult Delete(int id = 0)
//        {

//            var equipo = (from e in db.Equipo
//                          where e.idequipo == id
//                          select e).FirstOrDefault();
//            Modelo mod = new Modelo();
//            mod.equipo = equipo;
//            mod.equipo.descripcion = equipo.descripcion;
//            ViewBag.idmarca = new SelectList(db.Marca, "idmarca", "descripcion");
//            return View(mod);

             
//        }

//        //
//        // POST: /Equipo/Delete/5

//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Equipo equipo = db.Equipo.Find(id);
//            db.Equipo.Remove(equipo);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        //public string AutogeneradoEquipo()
//        //{
//        //    string formatNumber = "0000";

//        //        int ultimoCodigo = db.usp_obtenerUltimoEquipo().SingleOrDefault();
//        //    string nuevo = null;

//        //    if (!(ultimoCodigo == null || ultimoCodigo.Length == 0))
//        //    {
//        //        int c = Convert.ToInt32(ultimoCodigo.Substring(5)) + 1;
//        //        nuevo = "TRAB-" + c.ToString(formatNumber);
//        //    }
//        //    else
//        //    {
//        //        nuevo = "TRAB-0001";
//        //    }

//        //    return nuevo;
//        //}

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}