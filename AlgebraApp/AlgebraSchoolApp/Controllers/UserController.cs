using AlgebraSchoolApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSchoolApp.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db;

        public UserController()
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
        public ActionResult Edit(ApplicationUser Iuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Iuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Iuser);
        }
    }
}