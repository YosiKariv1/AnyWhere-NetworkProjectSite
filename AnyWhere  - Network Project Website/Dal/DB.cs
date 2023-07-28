using AnyWhere____Network_Project_Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnyWhere___Network_Project_WebSite.Dal
{
    public class DB : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().ToTable("UsersDB");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flights>().ToTable("FlightsDB");     
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>().ToTable("BooksDB");
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Flights> flights { get; set; }
        public DbSet<Booking> books { get; set; }
    }
}