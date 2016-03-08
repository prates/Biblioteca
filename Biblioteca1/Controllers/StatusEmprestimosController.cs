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
    public class StatusEmprestimosController : Controller
    {
        private ModelBiblioteca db = new ModelBiblioteca();

        // GET: StatusEmprestimos
        public ActionResult Index()
        {
            return View(db.StatusEmprestimo.ToList());
        }

        // GET: StatusEmprestimos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusEmprestimos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Label")] StatusEmprestimo statusEmprestimo)
        {
            if (ModelState.IsValid)
            {
                db.StatusEmprestimo.Add(statusEmprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusEmprestimo);
        }

        // GET: StatusEmprestimos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusEmprestimo statusEmprestimo = db.StatusEmprestimo.Find(id);
            if (statusEmprestimo == null)
            {
                return HttpNotFound();
            }
            return View(statusEmprestimo);
        }

        // POST: StatusEmprestimos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Label")] StatusEmprestimo statusEmprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusEmprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusEmprestimo);
        }

        // GET: StatusEmprestimos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusEmprestimo statusEmprestimo = db.StatusEmprestimo.Find(id);
            if (statusEmprestimo == null)
            {
                return HttpNotFound();
            }
            return View(statusEmprestimo);
        }

        // POST: StatusEmprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusEmprestimo statusEmprestimo = db.StatusEmprestimo.Find(id);
            db.StatusEmprestimo.Remove(statusEmprestimo);
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
