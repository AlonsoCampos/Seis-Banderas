﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExtraUTTEntities : DbContext
    {
        public ExtraUTTEntities()
            : base("name=ExtraUTTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<ExtraEscolares> ExtraEscolares { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
    }
}
