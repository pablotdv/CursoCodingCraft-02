using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFHerancaComposicao.Models;

namespace EFHerancaComposicao.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PessoaFisicas
        public async Task<ActionResult> Index()
        {
            var pessoas = db.PessoaFisicas.Include(p => p.Cliente).Include(p => p.Fornecedor);
            return View(await pessoas.ToListAsync());
        }

        // GET: PessoaFisicas/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoaFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Create
        public ActionResult Create()
        {
            ViewBag.PessoaId = new SelectList(db.Clientes, "PessoaId", "PessoaId");
            ViewBag.PessoaId = new SelectList(db.Fornecedors, "PessoaId", "PessoaId");
            return View();
        }

        // POST: PessoaFisicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PessoaId,CpfCnpj,NomeOuRazaoSocial,Rg,DataNascimento")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                pessoaFisica.PessoaId = Guid.NewGuid();
                db.Pessoas.Add(pessoaFisica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaId = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            ViewBag.PessoaId = new SelectList(db.Fornecedors, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoaFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaId = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            ViewBag.PessoaId = new SelectList(db.Fornecedors, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PessoaId,CpfCnpj,NomeOuRazaoSocial,Rg,DataNascimento")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaFisica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaId = new SelectList(db.Clientes, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            ViewBag.PessoaId = new SelectList(db.Fornecedors, "PessoaId", "PessoaId", pessoaFisica.PessoaId);
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaFisica pessoaFisica = await db.PessoaFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return HttpNotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PessoaFisica pessoaFisica = await db.PessoaFisicas.FindAsync(id);
            db.Pessoas.Remove(pessoaFisica);
            await db.SaveChangesAsync();
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
