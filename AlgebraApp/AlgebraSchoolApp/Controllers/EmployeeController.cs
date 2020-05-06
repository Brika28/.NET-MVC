using AlgebraSchoolApp.Models;
using DataAccesLayer.Repositories;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSchoolApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            var role = (from r in db.Roles where r.Name.Contains("Zaposlenik") select r).FirstOrDefault();
            var users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            var userVM = users.Select(user => new EmployeeViewModel
            {
                UserName = user.UserName,
                Roles = "Zaposlenik"
            }).ToList();


            var role2 = (from r in db.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            var admins = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

            var adminVM = admins.Select(user => new EmployeeViewModel
            {
                UserName = user.UserName,
                Roles = "Admin"
            }).ToList();


            var model = new GroupedUserViewModel { Users = userVM, Admins = adminVM };
            return View(model);
        }

    }
}