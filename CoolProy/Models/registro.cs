using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class registro
    {
        public int idempleado { get; set; } 
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string responsable { get; set; }
        public List<Empleado> empleados { get; set; }
    }
}