using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolProy.Models
{
    public class Producto1
    {
         
    
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public  int idmodelo { get; set; }
        public  int idmarca { get; set; } 
        public virtual ICollection<Det_Producto> Det_Producto { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
    }
 