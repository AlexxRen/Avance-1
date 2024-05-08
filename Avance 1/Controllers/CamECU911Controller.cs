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
    public class CamECU911Controller : Controller
    {
        private readonly Avance_1Context _context;

        public CamECU911Controller(Avance_1Context context)
        {
            _context = context;
        }

        // GET: CamECU911
        public async Task<IActionResult> Index()
        {
            return View(await _context.CamECU911.ToListAsync());
        }

        // GET: CamECU911/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camECU911 = await _context.CamECU911
                .FirstOrDefaultAsync(m => m.IdCam == id);
            if (camECU911 == null)
            {
                return NotFound();
            }

            return View(camECU911);
        }

        // GET: CamECU911/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CamECU911/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCam,Ubicacion,IdZona")] CamECU911 camECU911)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camECU911);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camECU911);
        }

        // GET: CamECU911/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camECU911 = await _context.CamECU911.FindAsync(id);
            if (camECU911 == null)
            {
                return NotFound();
            }
            return View(camECU911);
        }

        // POST: CamECU911/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCam,Ubicacion,IdZona")] CamECU911 camECU911)
        {
            if (id != camECU911.IdCam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camECU911);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamECU911Exists(camECU911.IdCam))
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
            return View(camECU911);
        }

        // GET: CamECU911/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camECU911 = await _context.CamECU911
                .FirstOrDefaultAsync(m => m.IdCam == id);
            if (camECU911 == null)
            {
                return NotFound();
            }

            return View(camECU911);
        }

        // POST: CamECU911/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camECU911 = await _context.CamECU911.FindAsync(id);
            if (camECU911 != null)
            {
                _context.CamECU911.Remove(camECU911);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamECU911Exists(int id)
        {
            return _context.CamECU911.Any(e => e.IdCam == id);
        }
    }
}
