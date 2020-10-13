using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PontoID.Web.Data;
using PontoID.Web.Models;

namespace PontoID.Web.Controllers
{
    public class TurmaController : Controller
    {
        private readonly PontoIDWebContext _context;

        public TurmaController(PontoIDWebContext context)
        {
            _context = context;
        }

        // GET: Turma
        public async Task<IActionResult> Index()
        {
            var pontoIDWebContext = _context.TurmaViewModel.Include(t => t.Escola);
            return View(await pontoIDWebContext.ToListAsync());
        }

        // GET: Turma/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await _context.TurmaViewModel
                .Include(t => t.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaViewModel == null)
            {
                return NotFound();
            }

            return View(turmaViewModel);
        }

        // GET: Turma/Create
        public IActionResult Create()
        {
            ViewData["EscolaId"] = new SelectList(_context.EscolaViewModel, "Id", "Nome");
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
                turmaViewModel.Id = Guid.NewGuid();
                _context.Add(turmaViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaId"] = new SelectList(_context.EscolaViewModel, "Id", "Nome", turmaViewModel.EscolaId);
            return View(turmaViewModel);
        }

        // GET: Turma/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await _context.TurmaViewModel.FindAsync(id);
            if (turmaViewModel == null)
            {
                return NotFound();
            }
            ViewData["EscolaId"] = new SelectList(_context.EscolaViewModel, "Id", "Nome", turmaViewModel.EscolaId);
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
                try
                {
                    _context.Update(turmaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaViewModelExists(turmaViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaId"] = new SelectList(_context.EscolaViewModel, "Id", "Nome", turmaViewModel.EscolaId);
            return View(turmaViewModel);
        }

        // GET: Turma/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaViewModel = await _context.TurmaViewModel
                .Include(t => t.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var turmaViewModel = await _context.TurmaViewModel.FindAsync(id);
            _context.TurmaViewModel.Remove(turmaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaViewModelExists(Guid id)
        {
            return _context.TurmaViewModel.Any(e => e.Id == id);
        }
    }
}
