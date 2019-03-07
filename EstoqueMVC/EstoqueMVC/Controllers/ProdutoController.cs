using EstoqueMVC.EstoqueServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstoqueMVC.Controllers
{
    public class ProdutoController : Controller
    {
        readonly EstoqueServiceClient _wcf = new EstoqueServiceClient();
        
        // GET: Produto
        public ActionResult Index()
        {
            List<Produto> produtos = _wcf.encontraTodos().ToList();
            return View(produtos);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            Produto produto = _wcf.encontra(id);
            return View(produto);
        }

        // GET: Create
        public ActionResult Create()
        {
            Produto produto = new Produto();
            return View(produto);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _wcf.novo(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Produto produto = _wcf.encontra(id);
            return View(produto);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _wcf.atualiza(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            Produto produto = _wcf.encontra(id);
            return View(produto);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _wcf.deletaID(id);
            return RedirectToAction("Index");
        }

    }
}