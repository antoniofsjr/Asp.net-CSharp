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
    public class AlunoController : Controller
    {
        private EscolaEntities db = new EscolaEntities();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunoes = db.Alunoes.Include(a => a.Assunto).Include(a => a.Departamento);
            return View(alunoes.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.AssuntoID = new SelectList(db.Assuntoes, "AssuntoID", "Assunto1");
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "DepartamentoNome");
            return View();
        }

        // POST: Aluno/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoID,AlunoNome,DepartamentoID,AssuntoID")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssuntoID = new SelectList(db.Assuntoes, "AssuntoID", "Assunto1", aluno.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "DepartamentoNome", aluno.DepartamentoID);
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssuntoID = new SelectList(db.Assuntoes, "AssuntoID", "Assunto1", aluno.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "DepartamentoNome", aluno.DepartamentoID);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,AlunoNome,DepartamentoID,AssuntoID")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssuntoID = new SelectList(db.Assuntoes, "AssuntoID", "Assunto1", aluno.AssuntoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "DepartamentoNome", aluno.DepartamentoID);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunoes.Find(id);
            db.Alunoes.Remove(aluno);
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
