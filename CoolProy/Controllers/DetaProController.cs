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
    public class DetaProController : Controller
    {

       private  CoolEntities db = new CoolEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnadirProducto(Det_Producto detemp)
        {

            if (ModelState.IsValid)
            {
                db.Det_Producto.Add(detemp);
                db.SaveChanges();

            }
            return View();
        }
    }
}
