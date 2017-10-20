using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteEstagioAntonioFlavio.Models;

namespace TesteEstagioAntonioFlavio.Controllers
{
    public class AbtraController : Controller
    {
        // GET: Abtra
        public ActionResult Index()
        {
            AbtraDataBaseEntities db = new AbtraDataBaseEntities();

            return View(db.DataBase.ToList());
        }

    }

}