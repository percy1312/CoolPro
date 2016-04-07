using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class ModalSolicitudInspeccion
    {
        public CoolProy.Models.SolicitudInspeccion mdl1 { get; set; }
        public IEnumerable<CoolProy.Models.SolicitudInspeccion> mdl2 { get; set; }
    }
}