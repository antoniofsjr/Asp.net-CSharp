using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FechadoParaManutenção.Models;

namespace FechadoParaManutenção.Controllers
{
    public class TabAbtraController : Controller
    {
        private Abtra_Es_ProjectEntities db = new Abtra_Es_ProjectEntities();

        // GET: TabAbtra
        public ActionResult Index()
        {
            var tabAbtra = db.TabAbtra.Include(t => t.Assunto).Include(t => t.Departamento);
            return View(tabAbtra.ToList());
        }

        // GET: TabAbtra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabAbtra tabAbtra = db.TabAbtra.Find(id);
            if (tabAbtra == null)
            {
                return HttpNotFound();
            }
            return View(tabAbtra);
        }

        // GET: TabAbtra/Create
        public ActionResult Create()
        {
            ViewBag.AssuntoID = new SelectList(db.Assunto, "AssuntoID", "Assunto1");
            ViewBag.DepartamentoID = new SelectList(db.Departamento, "DepartamentoID", "DepartamentoNome");
            return View();
        }

        // POST: TabAbtra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoId,AlunoNome,CPF,DataDeNascimento,DepartamentoID,AssuntoID")] TabAbtra tabAbtra)
        {
            if (ModelState.IsValid)
            {
                db.TabAbtra.Add(tabAbtra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssuntoID = new SelectList(db.Assunto, "AssuntoID", "Assunto1", tabAbtra.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamento, "DepartamentoID", "DepartamentoNome", tabAbtra.DepartamentoID);
            return View(tabAbtra);
        }

        // GET: TabAbtra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabAbtra tabAbtra = db.TabAbtra.Find(id);
            if (tabAbtra == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssuntoID = new SelectList(db.Assunto, "AssuntoID", "Assunto1", tabAbtra.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamento, "DepartamentoID", "DepartamentoNome", tabAbtra.DepartamentoID);
            return View(tabAbtra);
        }

        // POST: TabAbtra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,AlunoNome,CPF,DataDeNascimento,DepartamentoID,AssuntoID")] TabAbtra tabAbtra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabAbtra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssuntoID = new SelectList(db.Assunto, "AssuntoID", "Assunto1", tabAbtra.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamento, "DepartamentoID", "DepartamentoNome", tabAbtra.DepartamentoID);
            return View(tabAbtra);
        }

        // GET: TabAbtra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabAbtra tabAbtra = db.TabAbtra.Find(id);
            if (tabAbtra == null)
            {
                return HttpNotFound();
            }
            return View(tabAbtra);
        }

        // POST: TabAbtra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabAbtra tabAbtra = db.TabAbtra.Find(id);
            db.TabAbtra.Remove(tabAbtra);
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
