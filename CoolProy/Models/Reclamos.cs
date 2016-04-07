using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class Reclamos
    {  public int idreclamo { get; set; }
        public string encargado { get; set; }
        public DateTime fecha { get; set; }
        public string contacto { get; set; }
        public int idcliente { get; set; }
        public int ruc { get; set; }
        public string direccion { get; set; }
        public string observacion { get; set; }
    }
}