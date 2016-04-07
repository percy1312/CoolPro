using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data;
using System.Data.Entity; 
using System.Web.Mvc;
using CoolProy.Models;

namespace CoolProy.Models
{
    public class Modal
    {
        public CoolProy.Models.SolicitudInspeccion mdl1 { get; set; }
        public IEnumerable<CoolProy.Models.Cliente> mdl2 { get; set; }
      
    }
}