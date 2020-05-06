using AlgebraSchoolApp.Models;
using DataAccesLayer.Repositories;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlgebraSchoolApp.Controllers
{
    [Authorize(Roles ="Admin")]
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
            ApplicationDbContext db = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (userManager.IsInRole(user.Id,"Zaposlenik"))
                {
                    ModelState.AddModelError("", "Korisnik je vec dodjeljen u zaposlenika.");
                    return View(user);
                }
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    ModelState.AddModelError("", "Korisnik je vec Admin.");
                    return View(user);
                }
                
                userManager.AddToRole(user.Id, "Zaposlenik");
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}