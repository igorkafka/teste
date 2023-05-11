using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TesteEmpresa.Interfaces;
using TesteEmpresa.Models;

namespace TesteEmpresa.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await _produtoRepository.ObterTodos());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _produtoRepository.ObterPorId(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid) return View(produto);
            try
            {
                await _produtoRepository.Adicionar(produto);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, Produto produto)
        {
            if (id != produto.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(produto);

            try
            {
                await _produtoRepository.Atualizar(produto);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, Produto produto)
        {
            var fornecedor = await _produtoRepository.ObterPorId(id);

            if (fornecedor == null) return HttpNotFound();

            _produtoRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
