﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportGit.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirportEntities1 : DbContext
    {
        public AirportEntities1()
            : base("name=AirportEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aircompany> Aircompany { get; set; }
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<AirplaneModel> AirplaneModel { get; set; }
        public virtual DbSet<Baggage> Baggage { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ClassReservation> ClassReservation { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightStatus> FlightStatus { get; set; }
        public virtual DbSet<Flyghtport> Flyghtport { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
    }
}