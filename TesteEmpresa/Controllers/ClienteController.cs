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
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await _clienteRepository.ObterTodos());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _clienteRepository.ObterPorId(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);
            try
            {
                await _clienteRepository.Adicionar(cliente);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, Cliente cliente)
        {
            if (id != cliente.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(cliente);

            try
            {
                await _clienteRepository.Atualizar(cliente);
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
            var cliente =  await _clienteRepository.ObterPorId(id);

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
            var fornecedor = await _clienteRepository.ObterPorId(id);

            if (fornecedor == null) return HttpNotFound();

            _clienteRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
