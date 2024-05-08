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
    public class SiniestroController : Controller
    {
        private readonly Avance_1Context _context;

        public SiniestroController(Avance_1Context context)
        {
            _context = context;
        }

        // GET: Siniestro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Siniestro.ToListAsync());
        }

        // GET: Siniestro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestro
                .FirstOrDefaultAsync(m => m.IdSiniestro == id);
            if (siniestro == null)
            {
                return NotFound();
            }

            return View(siniestro);
        }

        // GET: Siniestro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Siniestro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiniestro,FechaSiniestro,NivelUrgencia,Descripcion,IdZona,IdAgente")] Siniestro siniestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siniestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siniestro);
        }

        // GET: Siniestro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestro.FindAsync(id);
            if (siniestro == null)
            {
                return NotFound();
            }
            return View(siniestro);
        }

        // POST: Siniestro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiniestro,FechaSiniestro,NivelUrgencia,Descripcion,IdZona,IdAgente")] Siniestro siniestro)
        {
            if (id != siniestro.IdSiniestro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siniestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiniestroExists(siniestro.IdSiniestro))
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
            return View(siniestro);
        }

        // GET: Siniestro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siniestro = await _context.Siniestro
                .FirstOrDefaultAsync(m => m.IdSiniestro == id);
            if (siniestro == null)
            {
                return NotFound();
            }

            return View(siniestro);
        }

        // POST: Siniestro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siniestro = await _context.Siniestro.FindAsync(id);
            if (siniestro != null)
            {
                _context.Siniestro.Remove(siniestro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiniestroExists(int id)
        {
            return _context.Siniestro.Any(e => e.IdSiniestro == id);
        }
    }
}
