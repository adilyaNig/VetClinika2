﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VetClinika.DBConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinikaEntities1 : DbContext
    {
        public ClinikaEntities1()
            : base("name=ClinikaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Priem> Priem { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_Pet> Type_Pet { get; set; }
        public virtual DbSet<Type_Vrach> Type_Vrach { get; set; }
        public virtual DbSet<Vrach> Vrach { get; set; }
    }
}
