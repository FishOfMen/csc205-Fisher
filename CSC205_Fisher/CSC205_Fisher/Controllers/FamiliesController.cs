using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC205_Fisher.Models;

namespace CSC205_Fisher.Controllers
{
    public class FamiliesController : Controller
    {

        List<Families> families;

        public FamiliesController()
        {
            families = new List<Families>
            {
                new Families() { id=0, familyname = "Fisher", address1 = "917 Monroe Court", city = "Apollo", state = "PA", zip = "15613", homephone = "7247335201" },
                new Families() { id=1, familyname = "Johns", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Families() { id=2, familyname = "Ellis", address1 = "1 Sycamore Hollow", city = "Pittsburgh", state = "PA", zip = "15212", homephone = "4122371212" },
                new Families() { id=3, familyname = "Braddock", address1 = "23 Livingstone Dr", city = "Monroeville", state = "PA", zip = "15010", homephone = "4123277486" },
                new Families() { id=4, familyname = "Meier", address1 = "902 N Logan Ave", city = "colorado Springs", state = "CO", zip = "80909", homephone = "9286009335" },
                new Families() { id=5, familyname = "Grimm", address1 = "157 Jackson Rd", city = "Bay Villiage", state = "OH", zip = "48793", homephone = "4408739428" }            };
        }

        // GET: Families
        public ActionResult Index()
        {
            return View(families);
        }
    }
}