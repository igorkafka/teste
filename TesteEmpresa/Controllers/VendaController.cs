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
    public class VendaController : Controller
    {
        private IVendaRepository _vendaRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        public VendaController(IVendaRepository vendaRepository,IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
        }
        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await _vendaRepository.ObterTodos());
        }

        // GET: Cliente
        [HttpPost]
        public async Task<ActionResult> Index(string textoPesquisa)
        {
            return View(await _vendaRepository.PesquisarVenda(textoPesquisa));
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _vendaRepository.ObterPorId(id));
        }

        // GET: Cliente/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Produtos = await _produtoRepository.ObterTodos();
            ViewBag.Clientes = await _clienteRepository.ObterTodos();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(Venda venda)
        {
            if (!ModelState.IsValid) return View(venda);
            try
            {
                await _vendaRepository.Adicionar(venda);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.Produtos = await _produtoRepository.ObterTodos();
                ViewBag.Clientes = await _clienteRepository.ObterTodos();
                return View(venda);
            }
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var venda = await _vendaRepository.ObterPorId(id);

            if (venda == null)
            {
                return HttpNotFound();
            }

            return View(venda);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, Venda cliente)
        {
            if (id != cliente.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(cliente);

            try
            {
                await _vendaRepository.Atualizar(cliente);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var cliente = await _vendaRepository.ObterPorId(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, Cliente cliente)
        {
            var fornecedor = await _vendaRepository.ObterPorId(id);

            if (fornecedor == null) return HttpNotFound();

            _vendaRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
