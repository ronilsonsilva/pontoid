using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PontoID.Web.Models;
using PontoID.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PontoID.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly ITurmaService _turmaService;

        public AlunoController(IAlunoService alunoService, ITurmaService turmaService)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var alunos = await this._alunoService.Listar(new AlunoRequest());
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tasks = new Task[3];
            //var turmasDoAluno = await this._turmaService.Listar(new TurmaRequest(id, null));
            //var turmasDisponivel = await this._turmaService.Listar(new TurmaRequest());
            //var alunoViewModel = await this._alunoService.Detalhes(id);
            var turmasDoAluno = new List<TurmaViewModel>();
            var turmasDisponivel = new List<TurmaViewModel>();
            var alunoViewModel = new AlunoViewModel();

            tasks[0] = Task.Run(() => turmasDoAluno = this._turmaService.Listar(new TurmaRequest(id, null)).Result);
            tasks[1] = Task.Run(() => turmasDisponivel = this._turmaService.Listar(new TurmaRequest()).Result);
            tasks[2] = Task.Run(() => alunoViewModel = this._alunoService.Detalhes(id).Result);
            await Task.WhenAll(tasks);
            if (alunoViewModel == null)
            {
                return NotFound();
            }
            alunoViewModel.Turmas = turmasDoAluno;
            turmasDisponivel.RemoveAll(x => turmasDoAluno.Select(y => y.Id).Contains(x.Id));
            ViewData["Turmas"] = new SelectList(turmasDisponivel, "Id", "Nome");

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
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await this._alunoService.Detalhes(id);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await this._alunoService.Detalhes(id);
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
            var response = await this._alunoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarTurma(Guid id, [Bind("Nome,DataNascimento,Cpf,Id,Cadastro,Atualizado, TurmaId")] AlunoViewModel alunoViewModel)
        {
            var command = new AdicionarAlunoTurmaCommand(id, alunoViewModel.TurmaId);
            var response = await this._alunoService.AdicionarTurma(command);
            return RedirectToAction("Details", new { id = id });
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirTurma(Guid id, [Bind("Nome,DataNascimento,Cpf,Id,Cadastro,Atualizado, TurmaId")] AlunoViewModel alunoViewModel)
        {
            var command = new ExcluirAlunoTurmaCommand(id, alunoViewModel.TurmaId);
            var response = await this._alunoService.DeleteTurma(command);
            return RedirectToAction("Details", new { id = id });
        }


    }
}
