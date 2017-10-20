using Alumno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alumno.Controllers
{
    public class AbtraController : Controller
    {
        // GET: Abtra
        public ActionResult Index()
        {
            try
            {
                using (var db = new AbtraContextEntities())
                {

                    return View(db.Abtra.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }

                

            //return View(db.Abtra.ToList());
        }

        
        public ActionResult Create()
        {
            //AbtraContextEntities db = new AbtraContextEntities();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Abtra a)
        {
           /* if (!ModelState.IsValid)
                return View();
    */        try
            {

                using (var db = new AbtraContextEntities())
                {

                    a.FichaRegistro = DateTime.Now;

                    db.Abtra.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }
          
              
        }

        public ActionResult Edit()
        {
            //AbtraContextEntities db = new AbtraContextEntities();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Abtra a)
        {
            //AbtraContextEntities db = new AbtraContextEntities();

            return View();
        }

    }
}