using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC205_Fisher.Models;
using System.Web.Routing;

namespace CSC205_Fisher.Controllers
{
    public class FamiliesController : Controller
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
        }

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
                new Families() { id=5, familyname = "Grimm", address1 = "157 Jackson Rd", city = "Bay Villiage", state = "OH", zip = "48793", homephone = "4408739428" }
            };
        }
        

        // GET: Families
        public ActionResult Index()
        {
            var Fams = Session["familyList"] as List<Families>;
            return View(Fams);
        }

        // GET: Families/Create
        public ActionResult Create()
        {
            var Fams = Session["familyList"] as List<Families>;
            return View();
        }

        //POST: Families/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var Fams = Session["familyList"] as List<Families>;

            try
            {
                //Random rand = new Random();
                //int newid = rand.Next(5, 1000);

                Families family = new Families()
                {
                    id = Fams.Count(),
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };

                //Add new Family
                Fams = (List<Families>)Session["familyList"];
                Fams.Add(family);

                //save family
                Session["familyList"] = Fams;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Families/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Families/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                
                var Fams = (List<Families>)Session["familyList"];

                var f = Fams[id];

                Families newFam = new Families()
                {
                    id = f.id,
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };

                Fams.Where(x => x.id == id).First().familyname = collection["familyname"];
                Fams.Where(x => x.id == id).First().address1 = collection["address1"];
                Fams.Where(x => x.id == id).First().city = collection["city"];
                Fams.Where(x => x.id == id).First().state = collection["state"];
                Fams.Where(x => x.id == id).First().zip = collection["zip"];
                Fams.Where(x => x.id == id).First().homephone = collection["homephone"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Something Bad Happend");
            }
        }

        //POST: Families/Delete/
        public ActionResult Delete(int id)
        {
            var Fams = (List<Families>)Session["familyList"];

            var f = Fams[id];

            Session["familyList"] = Fams.Where(x => x.id != id).ToList();

            Fams = (List<Families>)Session["familyList"];

            for (int x=id; x<Fams.Count(); x++)
            {
                if(Fams[x] != null)
                {
                    Fams[x].id = x;
                }
            }

            return RedirectToAction("Index");
        }
    }
}