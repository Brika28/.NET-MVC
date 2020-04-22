using AlgebraSchoolApp.Models;
using DataAccesLayer.Repositories;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlgebraSchoolApp.Controllers
{
    public class UsersController : Controller
    {
        private EmployesRepo er = new EmployesRepo();

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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult AddEmployee(string id)
        {
            ApplicationUser user = new ApplicationUser();

            user = db.Users.Find(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(ApplicationUser user)
        {

            Employee employee = new Employee();

            employee = new Employee { FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName};

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}