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
    
    public partial class Usuario
    {
        public string usuario1 { get; set; }
        public string clave { get; set; }
        public int idRol { get; set; }
        public bool verificadoUsuario { get; set; }
        public bool estadoUsuario { get; set; }
    
        public virtual tb_rol tb_rol { get; set; }
    }
}
