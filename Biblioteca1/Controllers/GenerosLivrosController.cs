using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteca1;
using Biblioteca1.Helpers;

namespace Biblioteca1.Controllers
{
    public class GenerosLivrosController : Controller
    {
        private ModelBiblioteca db = new ModelBiblioteca();
        [HttpGet]
        public ActionResult Create(int? livroId)
        {
            livroId = 4;
            Livro livro = db.Livro.Find(livroId);
            List<Genero> generos = db.Genero.ToList();
            ViewModel viewModel = new ViewModel(livro, generos);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroID, GeneroID")] GeneroLivro gl)
        {
            if (ModelState.IsValid)
            {
                db.GeneroLivro.Add(gl);
                db.SaveChanges();
                return RedirectToAction("Editar", "Livros");
            }

            return View(gl);
        }

        // GET: Generos/Delete/5
        public ActionResult Delete(int? livroId, int? generoId)
        {
            if (livroId == null || generoId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneroLivro gl = db.GeneroLivro.Where(u => u.LivroID == livroId && u.GeneroID == generoId).FirstOrDefault();
            if (gl == null)
            {
                return HttpNotFound();
            }
            return View(gl);
        }

        // POST: Generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = db.Genero.Find(id);
            db.Genero.Remove(genero);
            db.SaveChanges();
            return RedirectToAction("Editar", "Livros");
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
