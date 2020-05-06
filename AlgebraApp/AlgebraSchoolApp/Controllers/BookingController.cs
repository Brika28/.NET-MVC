using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccesLayer.Repositories;
using DataAccesLayer.Models;
using Entities;
using System.Net;
using Entities.Models;
using AlgebraSchoolApp.Models;
using System.Data.Entity;

namespace AlgebraSchoolApp.Controllers
{
    [Authorize(Roles="Admin,Zaposlenik")]
    public class BookingController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private BookingsRepo br = new BookingsRepo();

        public ActionResult Index()
        {
            return View(db.Bookings.Include(x => x.Course));
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = new SelectList(db.Courses.Where(x => x.Full == false), "CourseId", "CourseName");
            return View(new Booking());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking)
        {
            ViewBag.Courses = new SelectList(db.Courses.Where(x => x.Full == false), "CourseId", "CourseName");

            if (ModelState.IsValid)
            {
                booking.DateOfBooking = DateTime.Now.Date;
                br.CreateBooking(booking);
                var book = db.Bookings.Include(x => x.Course).Where(x => x.BookingId == booking.BookingId);               
                return View("CreatedBooking",book);
            }
            return View(booking);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking booking = br.GetBooking((int)id);


            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = new SelectList(db.Courses.Where(x => x.Full == false), "CourseId", "CourseName");
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                br.UpdateBooking(booking);
                return RedirectToAction("Index");
            }
            ViewBag.Courses = new SelectList(db.Courses.Where(x => x.Full == false), "CourseId", "CourseName", booking.CourseId);
            return View(booking);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking booking = db.Bookings.Include(x => x.Course).Where(x => x.BookingId == id).SingleOrDefault();

            if (booking == null)
            {
                return HttpNotFound();
            }

            return View(booking);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking booking = db.Bookings.Include(x => x.Course).Where(x => x.BookingId == id).SingleOrDefault();

            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            br.DeleteBooking(id);
            return RedirectToAction("Index");
        }



    }
}