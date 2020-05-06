using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext() : base("connStr")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
