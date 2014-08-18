using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extra.Models;
using System.Data;
namespace Extra.Controllers
{
    
    public class PeriodoController : Controller
    {
        //
        // GET: /Periodo/
        private ExtraUTTEntities db = new ExtraUTTEntities();
        public ActionResult Index()
        {
            return View(db.Periodo.ToList());
        }
        public ActionResult AgregarPeriodo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarPeriodo(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodo.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodo);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Periodo periodo = db.Periodo.Find(id);
            return View(periodo);
        }

        [HttpPost, ActionName ("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            Periodo periodo = db.Periodo.Find(id);
            db.Periodo.Remove(periodo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            if (ModelState.IsValid)
            {
                Periodo periodo = db.Periodo.Find(id);
                return View(periodo);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodo);
        }

        public ActionResult Detalles(int id)
        {
            Periodo periodo = db.Periodo.Find(id);
            return View(periodo);
        }
    }
}
