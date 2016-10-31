using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC205_Fisher.Models;
using System.Web.Routing;

namespace CSC205_Fisher.Controllers
{
    public class PeopleController : Controller
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["peopleList"] == null)
            {
                Session["peopleList"] = people;
            }
        }

        List<People> people;

        public PeopleController()
        {
            people = new List<People>
            {
                new People() { id=0, firstname = "Zack", middlename = "S", lastname = "Fisher", cell = "4125540408", relationship = "son", familyId = 0 },
                new People() { id=1, firstname="Matt" , middlename="T" , lastname="Fisher" , cell="4120784623" , relationship="son" , familyId=0 },
                new People() { id=2, firstname="Brian" , middlename="T" , lastname="Fisher" , cell="4126910926" , relationship="dad" , familyId=0 },
                new People() { id=3, firstname="Laurie" , middlename="D" , lastname="Fisher" , cell="4120654028" , relationship="mom" , familyId=0 },
                new People() { id=4, firstname="Ryan" , middlename="G" , lastname="Grimm" , cell="4408566917" , relationship="son" , familyId=5 },
                new People() { id=5, firstname="Jimmy" , middlename="J" , lastname="Johns" , cell="6075556758" , relationship="dad" , familyId=1 },
                new People() { id=6, firstname="Stacey" , middlename="H" , lastname="Johns" , cell="6075556757" , relationship="mom" , familyId=1 },
                new People() { id=7, firstname="Ian" , middlename="F" , lastname="Johns" , cell="6075552257" , relationship="son" , familyId=1 },
                new People() { id=8, firstname="Avery" , middlename="K" , lastname="Johns" , cell="6075534757" , relationship="daughter" , familyId=1 },
                new People() { id=9, firstname="Roy" , middlename="F" , lastname="Ellis" , cell="9035534757" , relationship="dad" , familyId=2 },
                new People() { id=10, firstname="Michelle" , middlename="" , lastname="Ellis" , cell="9035531947" , relationship="mom" , familyId=2 },
                new People() { id=11, firstname="Bernie" , middlename="S" , lastname="Braddock" , cell="8145534757" , relationship="mom" , familyId=3 },
                new People() { id=12, firstname="Mark" , middlename="P" , lastname="Anderson" , cell="3025534757" , relationship="son" , familyId=3 }
            };
        }

        

        // GET: People
        public ActionResult Index()
        {
            return View(people);
        }

        // GET: Person/Profile/5
        public ActionResult Profile(int id)
        {
            // Get the list of people from the session
            var personList = (List<People>)Session["peopleList"];

            // Get the person with the passed in ID
            var p = personList[id];

            // Return the person data to the view
            return View(p);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                People person = new People()
                {
                    id = 99,
                    firstname = collection["firstname"],
                    middlename = collection["middlename"],
                    lastname = collection["lastname"],
                    cell = collection["cell"],
                    relationship = collection["relationship"],
                    familyId = int.Parse(collection["familyId"]
                    )
                };
                
                // Add a new person
                people = (List<People>)Session["peopleList"];
                people.Add(person);

                //Save to list
                Session["peopleList"] = people;

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Person/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Person/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}