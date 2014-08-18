using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extra.Models;
using System.Data;
namespace Extra.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ExtraUTTEntities db = new ExtraUTTEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Actividad()
        {
            return View(db.Actividad.ToList());
        }
        
        public ActionResult Detalles(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            return View(actividad);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Agregar(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Actividad");
            }
            return View(actividad);
        }
        
        public ActionResult Modificar(int id)
        {
            if (ModelState.IsValid)
            {
                Actividad actividad = db.Actividad.Find(id);
                return View(actividad);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Actividad");
            }
            return View(actividad);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            return View(actividad);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
            db.SaveChanges();
            return RedirectToAction("Actividad");
        }



    }
}
