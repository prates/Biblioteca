using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca1;

namespace Biblioteca1.Controllers
{
    public class EmprestimoesController : Controller
    {
        private ModelBiblioteca db = new ModelBiblioteca();

        // GET: Emprestimoes
        public ActionResult Index()
        {
            var emprestimo = db.Emprestimo.Include(e => e.Livro).Include(e => e.StatusEmprestimo);
            return View(emprestimo.ToList());
        }

        // GET: Emprestimoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public ActionResult Create()
        {
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo");
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label");
            return View();
        }

        // POST: Emprestimoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroID,StatusEmprestimoID,DataEmprestimo,DataDevolucao,Prazo,Multa,UsuarioID")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimo.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LivroID,StatusEmprestimoID,DataEmprestimo,DataDevolucao,Prazo,Multa,UsuarioID")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            db.Emprestimo.Remove(emprestimo);
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
