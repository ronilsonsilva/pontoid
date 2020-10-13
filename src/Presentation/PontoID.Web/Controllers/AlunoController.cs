using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoID.Web.Data;
using PontoID.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PontoID.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly PontoIDWebContext _context;

        public AlunoController(PontoIDWebContext context)
        {
            _context = context;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlunoViewModel.ToListAsync());
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _context.AlunoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
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
                alunoViewModel.Id = Guid.NewGuid();
                _context.Add(alunoViewModel);
                await _context.SaveChangesAsync();
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

            var alunoViewModel = await _context.AlunoViewModel.FindAsync(id);
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
                try
                {
                    _context.Update(alunoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoViewModelExists(alunoViewModel.Id))
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
            return View(alunoViewModel);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _context.AlunoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var alunoViewModel = await _context.AlunoViewModel.FindAsync(id);
            _context.AlunoViewModel.Remove(alunoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoViewModelExists(Guid id)
        {
            return _context.AlunoViewModel.Any(e => e.Id == id);
        }
    }
}
