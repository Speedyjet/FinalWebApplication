using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalWebApplication.Models;

namespace FinalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EmployeeContext();
            ViewData["EmployeeList"] = context.GetEmployeeList();
            return View();
        }

      
    }
}