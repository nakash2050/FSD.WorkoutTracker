using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkoutTracker.Web.Controllers
{
    public class ViewAllController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewAll");
        }
    }
}