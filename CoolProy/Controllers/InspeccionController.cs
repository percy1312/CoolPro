using System;
using System.Collections.Generic;
using Newtonsoft.Json; 
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolProy.Models;
using System.Data.SqlClient;
namespace CoolProy.Controllers
{
    public class InspeccionController : Controller
    {
        private CoolEntities db = new CoolEntities();

        //
        // GET: /Inspeccion/

        public ActionResult IndexInspeccion2()
        {

            var inspeccion = db.Inspeccion.Include(i => i.estado).Include(i => i.SolicitudInspeccion).Include(i => i.TipoServicio);
            var inspecciones = from e in db.Inspeccion
                               select e;

            ViewBag.ocultarCategorias = false;
            ViewBag.inspecciones = inspecciones.ToList();


            return View();
        }

        public ActionResult Index()
        {

            var inspeccion = db.Inspeccion.Include(i => i.estado).Include(i => i.SolicitudInspeccion).Include(i=> i.TipoServicio);
            var inspecciones = from e in db.Inspeccion
                          select e;

            ViewBag.ocultarCategorias = false;
            ViewBag.inspecciones = inspecciones.ToList();

            
            return View();
        }
         

        public ActionResult Details(int id = 0)
        {
            Inspeccion inspeccion = db.Inspeccion.Find(id);
            if (inspeccion == null)
            {
                return HttpNotFound();
            }
            return View(inspeccion);
        }
         
      




        public ActionResult Create(int id=0)
        { 
            IEnumerable<Empleado> empleados = db.Empleado.ToList();
            IEnumerable<Producto> productos = db.Producto.ToList();
            Inspeccion i = new Inspeccion();

            SolicitudInspeccion s = db.SolicitudInspeccion.Find(id); 
            
          
            Encap m = new Encap();
            m.mdinspecion = i; 
            m.listpro = productos;
            m.listemple = empleados;
            m.solicitudinspeccion = s; 

            ViewBag.idsolicitud = new SelectList(db.SolicitudInspeccion, "idsolicitud");
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion");
            ViewBag.idtiposervi = new SelectList(db.TipoServicio, "idtiposervi", "descripcion");
            return View(m);
        }

        public ActionResult listadetallepro()
        {
            var listadetallepro = (from det in db.Det_Producto where det.idinspeccion == 1 select det).ToList();
            //db.Det_Producto.ToList();
            return View(listadetallepro);
        }

        public ActionResult AnadirProducto()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AnadirProducto(Det_Producto detemp,int idinspeccion)
        {
            Inspeccion i = new Inspeccion();
            Encap e = new Encap();
            var listadetallepro = (from det in db.Det_Producto where det.idinspeccion == idinspeccion select det).ToList();
            e.listdepro = listadetallepro;
            
                db.Det_Producto.Add(detemp);
                db.SaveChanges();
                //return RedirectToAction("Edit", "Inspeccion", new {idinspeccion=idinspeccion});
                return PartialView("_PartialDetalleP", e);
                //return Json(listadetallepro, JsonRequestBehavior.AllowGet);
            //return View(detemp);
            //return PartialView("_PartialDetallePro", db.Det_Producto.ToList());
        }

        public ActionResult DeleteDet(int id, int idinspeccion)
        {
            Encap e = new Encap();
            var listadetallepro = (from det in db.Det_Producto where det.idinspeccion == idinspeccion select det).ToList();
            e.listdepro = listadetallepro;
            db.Det_Producto.Remove(db.Det_Producto.Find(id));
            db.SaveChanges();
            return PartialView("_PartialDetalleP", e);
        }

        [HttpPost]
        public ActionResult Create(Inspeccion inspeccion,string textoConcatenado ,bool? resp)
        {
            
            //int[] idEmpleados = textoConcatenado.Split(',').ToArray(); 
            char[] MyChar = { ',' };
            string NewString = textoConcatenado.TrimEnd(MyChar);
            int[] idEmpleados = NewString.Split(',').Select(n => int.Parse(n)).ToArray();
              
            //string[] idEmpleados = textoConcatenado.Split(",".ToArray());
            
            if (ModelState.IsValid)
            {

                db.Inspeccion.Add(inspeccion);
                foreach (int emp in idEmpleados)
                {
                    Det_empleado det = new Det_empleado();  
                    { 
                        db.Det_empleado.Add(new Det_empleado { idempleado = emp , responsable=resp});
                    } 
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //IEnumerable<Empleado> empleados = db.Empleado.ToList();
            //IEnumerable<Producto> productos = db.Producto.ToList();
            //Encap m = new Encap();
            //m.mdinspecion = inspeccion;
            //m.listemple = empleados;
            //m.listpro = productos;

            ViewBag.idsolicitud = new SelectList(db.SolicitudInspeccion, "idsolicitud");
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", inspeccion.idestado);
            ViewBag.idtiposervi = new SelectList(db.TipoServicio, "idtiposervi", "descripcion",inspeccion.idtiposervi);
            return View(inspeccion);
        }
         

        public ActionResult Edit(int id = 0)
        {
            IEnumerable<Empleado> empleados = db.Empleado.ToList();
            IEnumerable<Producto> productos = db.Producto.ToList();
            IList<Producto> productos2 = db.Producto.ToList();
            Inspeccion inspeccion = db.Inspeccion.Find(id);

            var listadetalle= (from det in db.Det_empleado where det.idinspeccion==id select det).ToList() ;
            var listadetallepro = (from deta in db.Det_Producto where deta.idinspeccion==id select deta).ToList();

            Encap m = new Encap();
            m.mdinspecion = inspeccion;
            m.listpro = productos;
            m.productos = productos2;
            m.listemple = empleados;
            m.listdetemple = listadetalle;
            m.listdepro = listadetallepro;
            if (inspeccion == null)
            {
                return HttpNotFound();
            }
            //inspeccion.TipoServicio = db.TipoServicio.FirstOrDefault(m => m.idtiposervi == inspeccion.idtiposervi);
            //ViewBag.idsolicitud = new SelectList(db.SolicitudInspeccion, "idsolicitud");
            //ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion");
            ViewBag.idtiposervi = new SelectList(db.TipoServicio, "idtiposervi", "descripcion", inspeccion.idtiposervi);
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", inspeccion.idestado);
            return View(m);
        }

        //
        // POST: /Inspeccion/Edit/5

        [HttpPost]
        //public ActionResult Edit(Encap inspeccion, string idproductos, string cantidades)
        public ActionResult Edit(Encap inspeccion)
        {
            Inspeccion ins = inspeccion.mdinspecion;
            //char[] MyChar = { ',' };
            //string NewString = idproductos.TrimEnd(MyChar);
            //int[] idProductos = NewString.Split(',').Select(n => int.Parse(n)).ToArray();
            //string NewString2 = cantidades.TrimEnd(MyChar);
            //int[] Cantidades = NewString2.Split(',').Select(n => int.Parse(n)).ToArray();
                         Producto prod = new Producto();
                        
            if (ModelState.IsValid)
            {
                db.Entry(ins).State = EntityState.Modified;
                //var listas = idProductos.Zip(Cantidades, (p, c) => new { idProductos = p, Cantidades = c });
                //foreach (var pro in listas)
                //     {
                             
                           
                //        db.Det_Producto.Add(new Det_Producto { idproducto = pro.idProductos, idinspeccion = ins.idinspeccion ,cantidad=pro.Cantidades});
                             
                //     }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", inspeccion.mdinspecion.idestado);
            ViewBag.idtiposervi = new SelectList(db.TipoServicio, "idtiposervi", "descripcion", inspeccion.mdinspecion.idtiposervi);
            return View(ins);
        }

        //
        // GET: /Inspeccion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Inspeccion inspeccion = db.Inspeccion.Find(id);
            Encap mod = new Encap();
            mod.mdinspecion = inspeccion;
            if (inspeccion == null)
            {
                return HttpNotFound();
            }
            return View(mod);
        }

        //
        // POST: /Inspeccion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Inspeccion inspeccion = db.Inspeccion.Find(id);
            db.Inspeccion.Remove(inspeccion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Empleados()
        {
            var empleados = from p in db.Empleado  
                            //select p;

                            select new Empleado1
                            {
                                idEmpleado = p.idempleado,
                                nomEmpleado = p.nombre,
                                apeEmpleado = p.apellidos,
                                dni = (int)p.dni,
                            };

            ViewBag.empleados = empleados.ToList();
            return View();
        }

        public ActionResult CarroCompras()
        {
            ViewBag.ocultarCategorias = true;
            return View();
        }

        [HttpGet]
        public JsonResult SeleccionarTecnico(int? id)
        {  
           
            var emple = from p in db.Empleado
                        where p.idempleado == id
                        select p;

            if (id == 0)
            {
                return Json("Empleado no existe", JsonRequestBehavior.AllowGet);
            }

            return Json("Empleado agregado", JsonRequestBehavior.AllowGet);
        }


        //[HttpGet]
        //public JsonResult AddTecnico(Empleado empleado)
        //{  
        //    List<Empleado1> carro = (List<Empleado1>)Session["carro"];
        //    var emple = from p in db.Empleado
        //                where p.idempleado == empleado.idempleado
        //                //select p;
        //                select new Empleado1()
        //                {
        //                    idEmpleado = p.idempleado,
        //                    nomEmpleado = p.nombre,
        //                    dni = (int)p.dni,
        //                    apeEmpleado = p.apellidos
        //                };
        //    Empleado1 emp = (Empleado1)emple.FirstOrDefault();
           
        //    Inspeccion i = new Inspeccion();
            
        //    if (emp == null)
        //    {
        //        return Json("Empleado no se agrego", JsonRequestBehavior.DenyGet);
        //    }


        //    carro.Add(emp);
        //    db.SaveChanges();

        //    return Json("Empleado agregado", JsonRequestBehavior.DenyGet);
        //}
 
 

        public JsonResult Descartar(int? idemp)
        {
            List<Empleado1> carro = (List<Empleado1>)Session["carro"];
            Empleado1 emp = carro.Find(Empleado1 => Empleado1.idEmpleado == idemp);
            carro.Remove(emp);
            return Json("Empleado eliminado", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Tecnicos()
        {
            var empleados = db.Empleado.ToList();
            Encap mod = new Encap();
            mod.listemple = empleados;
            return View(mod);
        }

        public JsonResult GetEquipos()
        {
            var equipos = db.Producto.ToList();
            //var equipos = from e in db.Producto
            //              select new Producto
            //              {

            //                idproducto=e.idproducto,
            //                descripcion = e.descripcion,
            //                idmarca=e.idmarca,
            //                idmodelo=e.idmodelo
            //              };
            return Json(equipos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTecnicos()
        {
            var empleados = db.Empleado.ToList();
            return Json(empleados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTecnicos2()
        {

            List<Empleado1> carro = (List<Empleado1>)Session["carro"];
            var empleados = from p in db.Empleado
                            //select p;

                            select new Empleado1
                            {
                                idEmpleado = p.idempleado,
                                nomEmpleado = p.nombre,
                                apeEmpleado = p.apellidos,
                                dni = (int)p.dni,
                            };

            carro = empleados.ToList();
            return Json(carro, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarDetalle(Det_empleado detemple)
        {
            if (ModelState.IsValid)
            {
                db.Det_empleado.Add(detemple);
                //db.Det_empleado.Add(detemp);
                db.SaveChanges(); 
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}