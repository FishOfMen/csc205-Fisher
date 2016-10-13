using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC205_Fisher.Controllers
{
    public class FamiliesController : Controller
    {
        // GET: Families
        public ActionResult Index()
        {
            return View();
        }
    }
}