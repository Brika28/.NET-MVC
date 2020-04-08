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

namespace AlgebraSchoolApp.Controllers
{
    public class CourseController : Controller
    {
        private CoursesRepo cr = new CoursesRepo();
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var courses = cr.GetCourses();
            var courseCustomModel = new List<CourseCustomModel>();

            foreach (var course in courses)
            {
                var bookingCount = db.Bookings.Where(x => x.CourseId == course.CourseId).Where(x => x.Status == "Upisan").Count();
                courseCustomModel.Add(new CourseCustomModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Description = course.Description,
                    Date = course.Date.Date,
                    Full = course.Full,
                    BookingCount =  bookingCount
                });
            }
           return View(courseCustomModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Course());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                cr.CreateCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = cr.GetCourse((int)id);

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            { 
                cr.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = cr.GetCourse((int)id);

            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = cr.GetCourse((int)id);

            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            cr.DeleteCourse(id);
            return RedirectToAction("Index");
        }



    }
}