//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoolProy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public Producto()
        {
            this.Det_Producto = new HashSet<Det_Producto>();
        }
    
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> idmodelo { get; set; }
        public Nullable<int> idmarca { get; set; }
    
        public virtual ICollection<Det_Producto> Det_Producto { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}
