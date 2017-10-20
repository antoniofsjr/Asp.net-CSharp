using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TabelaAbtraController : Controller
    {
        private Abtra_Entities db = new Abtra_Entities();

        // GET: TabelaAbtra
        public ActionResult Index()
        {
            return View(db.TabelaAbtra.ToList());
        }

        // GET: TabelaAbtra/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaAbtra tabelaAbtra = db.TabelaAbtra.Find(id);
            if (tabelaAbtra == null)
            {
                return HttpNotFound();
            }
            return View(tabelaAbtra);
        }

        // GET: TabelaAbtra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabelaAbtra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Nome,Sobrenome,DataDeNascimento,Sexo,CPF,Endereço,Numero,Telefone,CEP,FichaDeCadastro")] TabelaAbtra tabelaAbtra)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tabelaAbtra.FichaDeCadastro = DateTime.Now;
                    db.TabelaAbtra.Add(tabelaAbtra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }

            }

            return View(tabelaAbtra);
        }

        // GET: TabelaAbtra/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaAbtra tabelaAbtra = db.TabelaAbtra.Find(id);
            if (tabelaAbtra == null)
            {
                return HttpNotFound();
            }
            return View(tabelaAbtra);
        }

        // POST: TabelaAbtra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Sobrenome,DataDeNascimento,Sexo,CPF,Endereço,Numero,Telefone,CEP,FichaDeCadastro")] TabelaAbtra tabelaAbtra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabelaAbtra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabelaAbtra);
        }

        // GET: TabelaAbtra/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaAbtra tabelaAbtra = db.TabelaAbtra.Find(id);
            if (tabelaAbtra == null)
            {
                return HttpNotFound();
            }
            return View(tabelaAbtra);
        }

        // POST: TabelaAbtra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TabelaAbtra tabelaAbtra = db.TabelaAbtra.Find(id);
            db.TabelaAbtra.Remove(tabelaAbtra);
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
