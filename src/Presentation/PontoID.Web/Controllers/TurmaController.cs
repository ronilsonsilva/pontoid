using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PontoID.Web.Helpers;
using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace PontoID.Web.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IEscolaService _escolaService;

        public TurmaController(ITurmaService turmaService, IEscolaService escolaService)
        {
            _turmaService = turmaService;
            _escolaService = escolaService;
        }

        // GET: Turma
        public async Task<IActionResult> Index()
        {
            var turmas = await this._turmaService.Listar(new TurmaRequest());
            return View(turmas);
        }

        // GET: Turma/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await this._turmaService.Detalhes(id);
            if (turmaViewModel == null)
            {
                return NotFound();
            }

            return View(turmaViewModel);
        }

        // GET: Turma/Create
        public async Task<IActionResult> Create()
        {
            var turmaViewModel = new TurmaViewModel();
            ViewData["EscolaId"] = new SelectList(await this._escolaService.Listar(), "Id", "Nome", turmaViewModel.EscolaId);
            ViewData["Turno"] = DataHelpers.Turnos(turmaViewModel.Turno);
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,Turno,EscolaId,Id,Cadastro,Atualizado")] TurmaViewModel turmaViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await this._turmaService.Adicionar(turmaViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaId"] = new SelectList(await this._escolaService.Listar(), "Id", "Nome", turmaViewModel.EscolaId);
            ViewData["Turno"] = DataHelpers.Turnos(turmaViewModel.Turno);
            return View(turmaViewModel);
        }

        // GET: Turma/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await this._turmaService.Detalhes(id);
            if (turmaViewModel == null)
            {
                return NotFound();
            }
            ViewData["EscolaId"] = new SelectList(this._escolaService.Listar().Result, "Id", "Nome", turmaViewModel.EscolaId);
            ViewData["Turno"] = DataHelpers.Turnos(turmaViewModel.Turno);
            return View(turmaViewModel);
        }

        // POST: Turma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Descricao,Turno,EscolaId,Id,Cadastro,Atualizado")] TurmaViewModel turmaViewModel)
        {
            if (id != turmaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await this._turmaService.Editar(turmaViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaId"] = new SelectList(await this._escolaService.Listar(), "Id", "Nome", turmaViewModel.EscolaId);
            ViewData["Turno"] = DataHelpers.Turnos(turmaViewModel.Turno);
            return View(turmaViewModel);
        }

        // GET: Turma/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await this._turmaService.Detalhes(id);
            if (turmaViewModel == null)
            {
                return NotFound();
            }

            return View(turmaViewModel);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await this._turmaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
