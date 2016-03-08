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
    [Authorize]
    public class EmprestimosController : Controller
    {
        private ModelBiblioteca db = new ModelBiblioteca();

        // GET: Emprestimos
        public ActionResult Index()
        {
            var emprestimo = db.Emprestimo.Include(e => e.Livro).Include(e => e.StatusEmprestimo).Include(e => e.Usuario);
            foreach(Emprestimo e in emprestimo)
            {
                e.calcularMulta();
            }
            return View(emprestimo.ToList());
        }

        // GET: Emprestimos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            emprestimo.calcularMulta();
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public ActionResult Create()
        {
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo");
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Emprestimos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LivroID,StatusEmprestimoID,DataEmprestimo,DataDevolucao,Prazo,Multa,UsuarioID")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimo.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", emprestimo.UsuarioID);
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimo.Find(id);
            emprestimo.calcularMulta();

            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", emprestimo.UsuarioID);
            
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LivroID,StatusEmprestimoID,DataEmprestimo,DataDevolucao,Prazo,Multa,UsuarioID")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                emprestimo.calcularMulta();
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroID = new SelectList(db.Livro, "Id", "Titulo", emprestimo.LivroID);
            ViewBag.StatusEmprestimoID = new SelectList(db.StatusEmprestimo, "Id", "Label", emprestimo.StatusEmprestimoID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", emprestimo.UsuarioID);
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
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

        // POST: Emprestimos/Delete/5
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
