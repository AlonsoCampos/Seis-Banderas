using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extra.Models;

namespace Extra.Controllers
{ 
    public class InstructoresController : Controller
    {
        private ExtraUTTEntities db = new ExtraUTTEntities();

        //
        // GET: /Instructores/

        public ViewResult Index()
        {
            return View(db.Instructor.ToList());
        }

        //
        // GET: /Instructores/Details/5

        public ViewResult Details(int id)
        {
            Instructor instructor = db.Instructor.Find(id);
            return View(instructor);
        }

        //
        // GET: /Instructores/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Instructores/Create

        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(instructor);
        }
        
        //
        // GET: /Instructores/Edit/5
 
        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructor.Find(id);
            return View(instructor);
        }

        //
        // POST: /Instructores/Edit/5

        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        //
        // GET: /Instructores/Delete/5
 
        public ActionResult Delete(int id)
        {
            Instructor instructor = db.Instructor.Find(id);
            return View(instructor);
        }

        //
        // POST: /Instructores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Instructor instructor = db.Instructor.Find(id);
            db.Instructor.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}