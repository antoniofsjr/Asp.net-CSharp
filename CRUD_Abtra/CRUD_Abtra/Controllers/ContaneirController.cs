using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Abtra.Models;

namespace CRUD_Abtra.Controllers
{
    public class ContaneirController : Controller
    {
        private ContaneirContext db = new ContaneirContext();

        // GET: Contaneir
        public ActionResult Index()
        {
            return View(db.Contaneir.ToList());
        }

        // GET: Contaneir/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contaneir contaneir = db.Contaneir.Find(id);
            if (contaneir == null)
            {
                return HttpNotFound();
            }
            return View(contaneir);
        }

        // GET: Contaneir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contaneir/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,LocalDePartida,Registro,DateFicha")] Contaneir contaneir)
        {
            if (ModelState.IsValid)
            {
                db.Contaneir.Add(contaneir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contaneir);
        }

        // GET: Contaneir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contaneir contaneir = db.Contaneir.Find(id);
            if (contaneir == null)
            {
                return HttpNotFound();
            }
            return View(contaneir);
        }

        // POST: Contaneir/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,LocalDePartida,Registro,DateFicha")] Contaneir contaneir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaneir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contaneir);
        }

        // GET: Contaneir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contaneir contaneir = db.Contaneir.Find(id);
            if (contaneir == null)
            {
                return HttpNotFound();
            }
            return View(contaneir);
        }

        // POST: Contaneir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contaneir contaneir = db.Contaneir.Find(id);
            db.Contaneir.Remove(contaneir);
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
