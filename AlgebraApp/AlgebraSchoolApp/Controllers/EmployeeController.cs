using DataAccesLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgebraSchoolApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployesRepo er = new EmployesRepo();
        
        public ActionResult Index()
        {
            return View(er.GetEmployees());
        }
    }
}