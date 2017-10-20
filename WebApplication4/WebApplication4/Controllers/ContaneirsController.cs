using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ContaneirsController : Controller
    {
        private ContanainerEntities db = new ContanainerEntities();

        // GET: Contaneirs
        public ActionResult Index(String ordenacao)
        {
            ViewBag.ordenacaoAtual = ordenacao;
            ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_Desc" : "";

            var clientes = from c in db.Contaneir select c;

            switch(ordenacao)
            {
                case "Nome_Desc":
                    clientes = clientes.OrderByDescending(s => s.Nome);
                    break;
                default:
                    clientes = clientes.OrderBy(s => s.Nome);
                    break;
            }


            return View(clientes.ToList());
        }

        // GET: Contaneirs/Details/5
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

        // GET: Contaneirs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contaneirs/Create
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

        // GET: Contaneirs/Edit/5
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

        // POST: Contaneirs/Edit/5
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

        // GET: Contaneirs/Delete/5
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

        // POST: Contaneirs/Delete/5
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
