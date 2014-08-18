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
    public class ExtraEscolaresController : Controller
    {
        private ExtraUTTEntities db = new ExtraUTTEntities();

        // GET: /ExtraEscolares/

        public ViewResult Index()
        {
                return View(db.ExtraEscolares.Include("Actividad").Include("Instructor").Include("Periodo").ToList());
        }

        // GET: /ExtraEscolares/Details/5

        public ViewResult Detalles(int id)
        {
            ExtraEscolares extraescolares = db.ExtraEscolares.Find(id);
            SelectList Periodos = new SelectList(db.Periodo.ToList(), "idPeriodo", "nombre");
            ViewBag.idPeriodo = Periodos;
            SelectList Actividades = new SelectList(db.Actividad.ToList(), "idActividad", "nombre");
            ViewBag.idActividad = Actividades;
            SelectList Instructores = new SelectList(db.Instructor.ToList(), "idInstructor", "nombre");
            ViewBag.idInstructor = Instructores;

            return View(extraescolares);
        }

        //
        // GET: /ExtraEscolares/Create

        public ActionResult Agregar()
        {
            SelectList Periodos = new SelectList(db.Periodo.ToList(), "idPeriodo", "nombre");
            ViewBag.idPeriodo = Periodos;
            SelectList Actividades = new SelectList(db.Actividad.ToList(), "idActividad", "nombre");
            ViewBag.idActividad = Actividades;
            SelectList Instructores = new SelectList(db.Instructor.ToList(), "idInstructor", "nombre");
            ViewBag.idInstructor = Instructores;
            return View();
        } 

        //
        // POST: /ExtraEscolares/Create

        [HttpPost]
        public ActionResult Agregar(ExtraEscolares extraescolares)
        {
            if (ModelState.IsValid)
            {
                db.ExtraEscolares.Add(extraescolares);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            return View(extraescolares);
        }
        
        //
        // GET: /ExtraEscolares/Edit/5
 
        public ActionResult Modificar(int id)
        {
            ExtraEscolares extraescolares = db.ExtraEscolares.Find(id);
            SelectList Periodos = new SelectList(db.Periodo.ToList(), "IdPeriodo", "Nombre", extraescolares.idPeriodo);
            ViewBag.idPeriodo = Periodos;
            SelectList Actividades = new SelectList(db.Actividad.ToList(), "idActividad", "nombre", extraescolares.idActividad);
            ViewBag.idActividad = Actividades;
            SelectList Instructores = new SelectList(db.Instructor.ToList(), "idInstructor", "Nombre", extraescolares.idInstructor);
            ViewBag.idInstructor = Instructores;
            return View(extraescolares);
        }

        //
        // POST: /ExtraEscolares/Edit/5

        [HttpPost]
        public ActionResult Modificar(ExtraEscolares extraescolares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraescolares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            SelectList Periodos = new SelectList(db.Periodo.ToList(), "IdPeriodo", "Nombre");
            ViewBag.idPeriodo = Periodos;
            SelectList Actividades = new SelectList(db.Actividad.ToList(), "idActividad", "nombre");
            ViewBag.idActividad = Actividades;
            SelectList Instructores = new SelectList(db.Instructor.ToList(), "idInstructor", "Nombre");
            ViewBag.idInstructor = Instructores;
            return View(extraescolares);
        }

        //
        // GET: /ExtraEscolares/Delete/5
 
        public ActionResult Eliminar(int id)
        {
            ExtraEscolares extraescolares = db.ExtraEscolares.Find(id);
            SelectList Periodos = new SelectList(db.Periodo.ToList(), "IdPeriodo", "Nombre", extraescolares.idPeriodo);
            ViewBag.idPeriodo = Periodos;
            SelectList Actividades = new SelectList(db.Actividad.ToList(), "idActividad", "nombre", extraescolares.idActividad);
            ViewBag.idActividad = Actividades;
            SelectList Instructores = new SelectList(db.Instructor.ToList(), "idInstructor", "Nombre", extraescolares.idInstructor);
            ViewBag.idInstructor = Instructores;
            return View(extraescolares);
        }

        //
        // POST: /ExtraEscolares/Delete/5

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {            
            ExtraEscolares extraescolares = db.ExtraEscolares.Find(id);
            db.ExtraEscolares.Remove(extraescolares);
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