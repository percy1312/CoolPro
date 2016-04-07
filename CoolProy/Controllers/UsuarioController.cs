using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolProy.Models;

namespace CoolProy.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        private CoolEntities c = new CoolEntities();

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Validar()
        {
            return View();
        }

    

        [HttpPost]
        public ActionResult Validar(string stusuario, string stpassword )
        {
            
               Usuario us = c.Usuario.FirstOrDefault(d => d.usuario1 == stusuario & d.clave == stpassword);
            if(us != null){
                if (us != null)
                {
                    Session["usuario"] = us;
                    Session["carro"] = new List<Empleado1>();
                    Session["mensaje"] = "Bienvenido, " + us.usuario1;
                    return RedirectToAction("Index", "Home");
                }
               
                return RedirectToAction("Index","Home");
            }
            else
            {

                Session["mensaje"] = "Correo o contraseña incorrectos, intente nuevamente";
                return View();
            }
        }

        public ActionResult logouUsuario()
        {
            Session["usuario"] = null;
            Session["carro"] = null;
            return RedirectToAction("Validar", "Usuario");
        }

        //public ActionResult NoHallado()
        //{
        //    ViewBag.Erro
        //    return View();
        //}

      
    }
}
