using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bus_Staj.Models
{
    public class DataContext : System.Data.Entity.DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Bus_Model> Bus_Models {get; set;}
        public DbSet<User> Users { get; set; }

    }
}