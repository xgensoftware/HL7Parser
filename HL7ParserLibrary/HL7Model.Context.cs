﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HL7Parser
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HL7DataEntities : DbContext
    {
        public HL7DataEntities()
            : base("name=HL7DataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SegmentConfiguration> SegmentConfigurations { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<MessageType> MessageTypes { get; set; }
        public virtual DbSet<TriggerEvent> TriggerEvents { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Version> Versions { get; set; }
        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<DataTypeColumn> DataTypeColumns { get; set; }
    }
}
