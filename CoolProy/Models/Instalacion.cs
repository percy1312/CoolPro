using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class Instalacion
    {

        public int idinstalacion { get; set; }
        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public string marcasugerida { get; set; }
        public string recomendaciones { get; set; }
        public int idequipo { get; set; }
        public int idcliente { get; set; }
        public int idtecnico { get; set; }
    }
}