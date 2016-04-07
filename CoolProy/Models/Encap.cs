using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class Encap
    {
        public Inspeccion mdinspecion { get; set; }
        public Usuario usuario { get; set; }
        public Cliente cliente { get; set; }
        public Producto mproducto { get; set; }
        public TipoServicio tiposervicio { get; set; }
        public Empleado empleado { get; set; }
        public SolicitudInspeccion solicitudinspeccion { get; set; }
        public CoolProy.Models.SolicitudInspeccion mdl1 { get; set; }
        public IEnumerable<CoolProy.Models.Cliente> mdl2 { get; set; }
        public IEnumerable<CoolProy.Models.SolicitudInspeccion> listsoli { get; set; }
        public CoolProy.Models.Empleado mdemple { get; set; }
        public IEnumerable<CoolProy.Models.Empleado> listemple { get; set; }
        public IEnumerable<CoolProy.Models.Producto> listpro { get; set; }
        public IEnumerable<CoolProy.Models.Det_empleado> listdetemple { get; set; }
        public IEnumerable<CoolProy.Models.Det_Producto> listdepro { get; set; }
        public IList<Producto> productos { get; set; }
        public Empleado1 empleado1 { get; set; }
        public Det_empleado detemple { get; set; }
        public Det_Producto detpro { get; set; }
        //public IEnumerable<CoolProy.Models.Cliente> mdl2 { get; set; }
        //public IEnumerable<CoolProy.Models.Equipo> equipos { get; set; 
    }
}