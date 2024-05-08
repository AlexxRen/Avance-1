using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avance_1.Data;
using Avance_1.Models;

namespace Avance_1.Controllers
{
    public class AgenteController : Controller
    {
        private readonly Avance_1Context _context;

        public AgenteController(Avance_1Context context)
        {
            _context = context;
        }

        // GET: Agente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agente.ToListAsync());
        }

        // GET: Agente/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agente
                .FirstOrDefaultAsync(m => m.IdAgente == id);
            if (agente == null)
            {
                return NotFound();
            }

            return View(agente);
        }

        // GET: Agente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgente,Descripcion,IdPersona,idRole")] Agente agente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agente);
        }

        // GET: Agente/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agente.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }
            return View(agente);
        }

        // POST: Agente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAgente,Descripcion,IdPersona,idRole")] Agente agente)
        {
            if (id != agente.IdAgente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenteExists(agente.IdAgente))
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
            return View(agente);
        }

        // GET: Agente/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agente
                .FirstOrDefaultAsync(m => m.IdAgente == id);
            if (agente == null)
            {
                return NotFound();
            }

            return View(agente);
        }

        // POST: Agente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var agente = await _context.Agente.FindAsync(id);
            if (agente != null)
            {
                _context.Agente.Remove(agente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenteExists(string id)
        {
            return _context.Agente.Any(e => e.IdAgente == id);
        }
    }
}
