﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TeamProjectEntities : DbContext
    {
        public TeamProjectEntities()
            : base("name=TeamProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Activities> Activities { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<EatPlace> EatPlace { get; set; }
        public DbSet<Entertainment> Entertainment { get; set; }
        public DbSet<Residence> Residence { get; set; }
        public DbSet<Supermarkets> Supermarkets { get; set; }
        public DbSet<Transport> Transport { get; set; }
    }
}
