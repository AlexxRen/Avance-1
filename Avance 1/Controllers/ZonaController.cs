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
    public class ZonaController : Controller
    {
        private readonly Avance_1Context _context;

        public ZonaController(Avance_1Context context)
        {
            _context = context;
        }

        // GET: Zona
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zona.ToListAsync());
        }

        // GET: Zona/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona
                .FirstOrDefaultAsync(m => m.IdZona == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // GET: Zona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZona,Descripcion_zona")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zona);
        }

        // GET: Zona/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }
            return View(zona);
        }

        // POST: Zona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdZona,Descripcion_zona")] Zona zona)
        {
            if (id != zona.IdZona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaExists(zona.IdZona))
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
            return View(zona);
        }

        // GET: Zona/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zona = await _context.Zona
                .FirstOrDefaultAsync(m => m.IdZona == id);
            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // POST: Zona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zona = await _context.Zona.FindAsync(id);
            if (zona != null)
            {
                _context.Zona.Remove(zona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonaExists(string id)
        {
            return _context.Zona.Any(e => e.IdZona == id);
        }
    }
}
