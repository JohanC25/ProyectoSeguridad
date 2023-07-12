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
    public class FrecuenciasController : Controller
    {
        private readonly ProyectoSeguridadContext _context;

        public FrecuenciasController(ProyectoSeguridadContext context)
        {
            _context = context;
        }

        // GET: Frecuencias
        public async Task<IActionResult> Index()
        {
              return _context.Frecuencia != null ? 
                          View(await _context.Frecuencia.ToListAsync()) :
                          Problem("Entity set 'ProyectoSeguridadContext.Frecuencia'  is null.");
        }

        // GET: Frecuencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Frecuencia == null)
            {
                return NotFound();
            }

            var frecuencia = await _context.Frecuencia
                .FirstOrDefaultAsync(m => m.id == id);
            if (frecuencia == null)
            {
                return NotFound();
            }

            return View(frecuencia);
        }

        // GET: Frecuencias/Create
        public IActionResult Create()
        {
            ViewBag.Frecuencias = new SelectList(Frecuencia.Frecuencias);
            ViewBag.Responsables = new SelectList(Frecuencia.Responsables);
            return View();
        }

        // POST: Frecuencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,actividad,frecuencia,responsable")] Frecuencia frecuencia1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frecuencia1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Frecuencias = new SelectList(Frecuencia.Frecuencias);
            ViewBag.Responsables = new SelectList(Frecuencia.Responsables);
            return View(frecuencia1);
        }

        // GET: Frecuencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Frecuencia == null)
            {
                return NotFound();
            }

            var frecuencia = await _context.Frecuencia.FindAsync(id);
            if (frecuencia == null)
            {
                return NotFound();
            }
            ViewBag.Frecuencias = new SelectList(Frecuencia.Frecuencias);
            ViewBag.Responsables = new SelectList(Frecuencia.Responsables);
            return View(frecuencia);
        }

        // POST: Frecuencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,actividad,frecuencia,responsable")] Frecuencia frecuencia1)
        {
            if (id != frecuencia1.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frecuencia1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrecuenciaExists(frecuencia1.id))
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
            ViewBag.Frecuencias = new SelectList(Frecuencia.Frecuencias);
            ViewBag.Responsables = new SelectList(Frecuencia.Responsables);
            return View(frecuencia1);
        }

        // GET: Frecuencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Frecuencia == null)
            {
                return NotFound();
            }

            var frecuencia = await _context.Frecuencia
                .FirstOrDefaultAsync(m => m.id == id);
            if (frecuencia == null)
            {
                return NotFound();
            }

            return View(frecuencia);
        }

        // POST: Frecuencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Frecuencia == null)
            {
                return Problem("Entity set 'ProyectoSeguridadContext.Frecuencia'  is null.");
            }
            var frecuencia = await _context.Frecuencia.FindAsync(id);
            if (frecuencia != null)
            {
                _context.Frecuencia.Remove(frecuencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrecuenciaExists(int id)
        {
          return (_context.Frecuencia?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
