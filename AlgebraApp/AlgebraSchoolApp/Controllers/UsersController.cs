using AlgebraSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSchoolApp.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db;

        public UsersController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }
    }
}