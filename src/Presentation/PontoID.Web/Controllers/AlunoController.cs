using Microsoft.AspNetCore.Mvc;
using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace PontoID.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var alunos = await this._alunoService.Listar(new AlunoRequest());
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await this._alunoService.Detalhes(id.Value);
            if (alunoViewModel == null)
            {
                return NotFound();
            }

            return View(alunoViewModel);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Cpf,Id,Cadastro,Atualizado")] AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await this._alunoService.Adicionar(alunoViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoViewModel);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await this._alunoService.Detalhes(id.Value);
            if (alunoViewModel == null)
            {
                return NotFound();
            }
            return View(alunoViewModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,DataNascimento,Cpf,Id,Cadastro,Atualizado")] AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await this._alunoService.Editar(alunoViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(alunoViewModel);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await this._alunoService.Detalhes(id.Value);
            if (alunoViewModel == null)
            {
                return NotFound();
            }

            return View(alunoViewModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await this._alunoService.Detalhes(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
