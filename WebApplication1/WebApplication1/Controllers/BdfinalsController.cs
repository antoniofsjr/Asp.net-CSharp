using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BdfinalsController : Controller
    {
        private FinalContext db = new FinalContext();

        // GET: Bdfinals
        public ActionResult Index()
        {
            return View(db.Bdfinal.ToList());
        }

        // GET: Bdfinals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdfinal bdfinal = db.Bdfinal.Find(id);
            if (bdfinal == null)
            {
                return HttpNotFound();
            }
            return View(bdfinal);
        }

        // GET: Bdfinals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bdfinals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Sobrenome,Telefone,DataNascimento,CPF,Sexo")] Bdfinal bdfinal)
        {
            if (ModelState.IsValid)
            {
                db.Bdfinal.Add(bdfinal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bdfinal);
        }

        // GET: Bdfinals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdfinal bdfinal = db.Bdfinal.Find(id);
            if (bdfinal == null)
            {
                return HttpNotFound();
            }
            return View(bdfinal);
        }

        // POST: Bdfinals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Sobrenome,Telefone,DataNascimento,CPF,Sexo")] Bdfinal bdfinal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdfinal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bdfinal);
        }

        // GET: Bdfinals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bdfinal bdfinal = db.Bdfinal.Find(id);
            if (bdfinal == null)
            {
                return HttpNotFound();
            }
            return View(bdfinal);
        }

        // POST: Bdfinals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bdfinal bdfinal = db.Bdfinal.Find(id);
            db.Bdfinal.Remove(bdfinal);
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
