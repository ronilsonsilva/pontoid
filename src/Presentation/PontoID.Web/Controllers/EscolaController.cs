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
    public class EscolaController : Controller
    {
        private readonly PontoIDWebContext _context;

        public EscolaController(PontoIDWebContext context)
        {
            _context = context;
        }

        // GET: EscolaViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EscolaViewModel.ToListAsync());
        }

        // GET: EscolaViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaViewModel = await _context.EscolaViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
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
                escolaViewModel.Id = Guid.NewGuid();
                _context.Add(escolaViewModel);
                await _context.SaveChangesAsync();
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

            var escolaViewModel = await _context.EscolaViewModel.FindAsync(id);
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
                try
                {
                    _context.Update(escolaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaViewModelExists(escolaViewModel.Id))
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
            return View(escolaViewModel);
        }

        // GET: EscolaViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolaViewModel = await _context.EscolaViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var escolaViewModel = await _context.EscolaViewModel.FindAsync(id);
            _context.EscolaViewModel.Remove(escolaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaViewModelExists(Guid id)
        {
            return _context.EscolaViewModel.Any(e => e.Id == id);
        }
    }
}
