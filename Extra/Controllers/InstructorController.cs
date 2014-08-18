using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extra.Models;

namespace Extra.Controllers
{
    public class InstructorController : Controller
    {
        //
        // GET: /Instructor/
        private ExtraUTTEntities db = new ExtraUTTEntities();
        
        public ActionResult InstructorIndex()
        {
            return View(db.Instructor.ToList());
        }


        [HttpGet]
        public ActionResult AgregarInstructor()
        {
            return View();
        }
        public ActionResult AgregarInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("InstructorIndex");
            }
            return View(instructor);
        }

        public ActionResult Modificar(int id)
        {
            if (ModelState.IsValid)
            {
                Instructor instruct = db.Instructor.Find(id);
                return View(instruct);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("InstructorIndex");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Instructor busqueda = db.Instructor.Find(id);
            return View(busqueda);
        }
        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            Instructor instructor = db.Instructor.Find(id);
            db.Instructor.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("InstructorIndex");
        }

        public ActionResult Detalles(int id)
        {
            Instructor busqueda = db.Instructor.Find(id);
            return View(busqueda);
        }

    }
}
