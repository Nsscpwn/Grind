﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grind
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GrindEntities : DbContext
    {
        public GrindEntities()
            : base("name=GrindEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Stat> Stats { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<UserLvl> UserLvls { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
    }
}