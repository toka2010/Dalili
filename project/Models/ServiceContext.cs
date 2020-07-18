namespace project.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ServiceContext : DbContext
    {
      
        public ServiceContext()
            : base("name=ServiceContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<School> Schools { get; set; }
  
    }

    
}