using AlgebraSchoolApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlgebraSchoolApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {

        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(IdentityRole role)
        {
            if (role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var RoleMan = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roleId = role.Id;
            role = RoleMan.FindById(roleId);
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var RoleMan = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = RoleMan.FindById(id);
            RoleMan.Delete(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}