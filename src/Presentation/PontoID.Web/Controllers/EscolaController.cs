using Microsoft.AspNetCore.Mvc;
using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace PontoID.Web.Controllers
{
    public class EscolaController : Controller
    {
        private readonly IEscolaService _escolaService;

        public EscolaController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        // GET: EscolaViewModels
        public async Task<IActionResult> Index()
        {
            var escolas = await this._escolaService.Listar();
            return View(escolas);
        }

        // GET: EscolaViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaViewModel = await this._escolaService.Detalhes(id.Value);
            if (escolaViewModel == null)
            {
                return NotFound();
            }

            return View(escolaViewModel);
        }

        // GET: EscolaViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EscolaViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CodigoINEP,Id,Cadastro,Atualizado")] EscolaViewModel escolaViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await this._escolaService.Adicionar(escolaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(escolaViewModel);
        }

        // GET: EscolaViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaViewModel = await this._escolaService.Detalhes(id.Value);
            if (escolaViewModel == null)
            {
                return NotFound();
            }
            return View(escolaViewModel);
        }

        // POST: EscolaViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,CodigoINEP,Id,Cadastro,Atualizado")] EscolaViewModel escolaViewModel)
        {
            if (id != escolaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await this._escolaService.Editar(escolaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(escolaViewModel);
        }

        // GET: EscolaViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaViewModel = await this._escolaService.Detalhes(id.Value);
            if (escolaViewModel == null)
            {
                return NotFound();
            }

            return View(escolaViewModel);
        }

        // POST: EscolaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await this._escolaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
