//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Extra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Periodo
    {
        public Periodo()
        {
            this.ExtraEscolares = new HashSet<ExtraEscolares>();
        }
    
        public int IdPeriodo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<ExtraEscolares> ExtraEscolares { get; set; }
    }
}
