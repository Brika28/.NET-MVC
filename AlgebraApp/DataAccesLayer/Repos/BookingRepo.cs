using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities;
using System.Data.Entity;

namespace DataAccesLayer.Repositories
{
    public class BookingsRepo
    {
        private AppDbContext db = new AppDbContext();

        public List<Booking> GetBookings()
        {
            return db.Bookings.ToList();
        }

        public Booking GetBooking(int id)
        {
            return db.Bookings.Find(id);
        }

        public void UpdateBooking(Booking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateBooking(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
        }
    }
}
