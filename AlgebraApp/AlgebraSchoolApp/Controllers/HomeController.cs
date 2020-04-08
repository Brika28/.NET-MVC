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

        public ActionResult Index()
        {
            IEnumerable<Course> courses = cr.GetCourses();
            return View(courses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}