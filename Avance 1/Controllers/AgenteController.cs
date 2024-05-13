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
            var avance_1Context = _context.Agente.Include(a => a.Persona).Include(a => a.Rol);
            return View(await avance_1Context.ToListAsync());
        }

        // GET: Agente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agente
                .Include(a => a.Persona)
                .Include(a => a.Rol)
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
            ViewData["Personaid"] = new SelectList(_context.Persona, "IdPersona", "IdPersona");
            ViewData["Rolid"] = new SelectList(_context.Rol, "IdRol", "IdRol");
            return View();


        }

        // POST: Agente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgente,Estado_Agente,Personaid,Rolid")] Agente agente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Personaid"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", agente.Personaid);
            ViewData["Rolid"] = new SelectList(_context.Rol, "IdRol", "IdRol", agente.Rolid);
            return View(agente);
        }

        // GET: Agente/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["Personaid"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", agente.Personaid);
            ViewData["Rolid"] = new SelectList(_context.Rol, "IdRol", "IdRol", agente.Rolid);
            return View(agente);
        }

        // POST: Agente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgente,Estado_Agente,Personaid,Rolid")] Agente agente)
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
            ViewData["Personaid"] = new SelectList(_context.Persona, "IdPersona", "IdPersona", agente.Personaid);
            ViewData["Rolid"] = new SelectList(_context.Rol, "IdRol", "IdRol", agente.Rolid);
            return View(agente);
        }

        // GET: Agente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agente = await _context.Agente
                .Include(a => a.Persona)
                .Include(a => a.Rol)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agente = await _context.Agente.FindAsync(id);
            if (agente != null)
            {
                _context.Agente.Remove(agente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenteExists(int id)
        {
            return _context.Agente.Any(e => e.IdAgente == id);
        }
    }
}
