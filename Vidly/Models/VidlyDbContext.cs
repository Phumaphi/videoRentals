using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class VidlyDbContext: DbContext
    {
        public VidlyDbContext()
            :base("DefaultConnection")
        { }

        public static VidlyDbContext Create()
        {
            return  new  VidlyDbContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}