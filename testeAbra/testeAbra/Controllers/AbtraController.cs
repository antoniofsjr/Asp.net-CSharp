using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testeAbra.Models;

namespace testeAbra.Controllers
{
    public class AbtraController : Controller
    {
        // GET: Abtra
        public ActionResult Index()
        {
            AbtraBDEntities db = new AbtraBDEntities();

            

            return View(db.Abtra.ToList());
        }

        public ActionResult Creato()
        {
            AbtraBDEntities db = new AbtraBDEntities();



            return View(db.Abtra.ToList());
        }

    }
}