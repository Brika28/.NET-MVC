using AlgebraSchoolApp.Models;
using DataAccesLayer.Models;
using DataAccesLayer.Repositories;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSchoolApp.Controllers
{
    public class HomeController : Controller
    {
        private CoursesRepo cr = new CoursesRepo();

        public ActionResult Index(string searchString)
        {
            IEnumerable<Course> courses = cr.GetCourses();

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CourseName.ToLower().Contains(searchString.ToLower()));
            }

            return View(courses);
        }
    }
}