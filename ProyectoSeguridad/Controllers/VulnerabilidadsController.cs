using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSeguridad.Data;
using ProyectoSeguridad.Models;

namespace ProyectoSeguridad.Controllers
{
    public class VulnerabilidadsController : Controller
    {
        private readonly ProyectoSeguridadContext _context;

        public VulnerabilidadsController(ProyectoSeguridadContext context)
        {
            _context = context;
        }

        // GET: Vulnerabilidads
        public async Task<IActionResult> Index()
        {
              return _context.Vulnerabilidad != null ? 
                          View(await _context.Vulnerabilidad.ToListAsync()) :
                          Problem("Entity set 'ProyectoSeguridadContext.Vulnerabilidad'  is null.");
        }

        // GET: Vulnerabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad
                .FirstOrDefaultAsync(m => m.id == id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }

            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vulnerabilidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombreVulnerabilidad,descripcionVulnerabilidad,cvss")] Vulnerabilidad vulnerabilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vulnerabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad.FindAsync(id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }
            return View(vulnerabilidad);
        }

        // POST: Vulnerabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreVulnerabilidad,descripcionVulnerabilidad,cvss")] Vulnerabilidad vulnerabilidad)
        {
            if (id != vulnerabilidad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vulnerabilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VulnerabilidadExists(vulnerabilidad.id))
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
            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad
                .FirstOrDefaultAsync(m => m.id == id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }

            return View(vulnerabilidad);
        }

        // POST: Vulnerabilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vulnerabilidad == null)
            {
                return Problem("Entity set 'ProyectoSeguridadContext.Vulnerabilidad'  is null.");
            }
            var vulnerabilidad = await _context.Vulnerabilidad.FindAsync(id);
            if (vulnerabilidad != null)
            {
                _context.Vulnerabilidad.Remove(vulnerabilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VulnerabilidadExists(int id)
        {
          return (_context.Vulnerabilidad?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
