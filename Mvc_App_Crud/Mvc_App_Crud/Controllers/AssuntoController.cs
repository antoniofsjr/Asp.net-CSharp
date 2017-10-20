using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_App_Crud.Models;

namespace Mvc_App_Crud.Controllers
{
    public class AssuntoController : Controller
    {
        private EscolaEntities db = new EscolaEntities();

        // GET: Assunto
        public ActionResult Index()
        {
            return View(db.Assuntoes.ToList());
        }

        // GET: Assunto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = db.Assuntoes.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // GET: Assunto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assunto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssuntoID,Assunto1")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                db.Assuntoes.Add(assunto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assunto);
        }

        // GET: Assunto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = db.Assuntoes.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: Assunto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssuntoID,Assunto1")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assunto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assunto);
        }

        // GET: Assunto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = db.Assuntoes.Find(id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: Assunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assunto assunto = db.Assuntoes.Find(id);
            db.Assuntoes.Remove(assunto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
