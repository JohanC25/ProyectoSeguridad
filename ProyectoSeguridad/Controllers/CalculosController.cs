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
    public class CalculosController : Controller
    {
        private readonly ProyectoSeguridadContext _context;

        public CalculosController(ProyectoSeguridadContext context)
        {
            _context = context;
        }
        public ActionResult CrearControl()
        {
            // Obtiene todos los Activos de la base de datos.
            var activos = _context.Activo.ToList();
            /*var vulner = _context.Vulnerabilidad.ToList();
            var amen = _context.Amenaza.ToList();*/

            // Pasa los Activos a la vista.
            return View(activos);
        }
        // GET: Calculos
        public async Task<IActionResult> Index()
        {
              return _context.Calculos != null ? 
                          View(await _context.Calculos.ToListAsync()) :
                          Problem("Entity set 'ProyectoSeguridadContext.Calculos'  is null.");
        }

        // GET: Calculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calculos == null)
            {
                return NotFound();
            }

            var calculos = await _context.Calculos
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculos == null)
            {
                return NotFound();
            }

            return View(calculos);
        }

        // GET: Calculos/Create
        public IActionResult Create()
        {
            // Carga los activos desde la base de datos
            var activos = _context.Activo.ToList();
            /*var vulner = _context.Vulnerabilidad.ToList();
            var amen = _context.Amenaza.ToList();*/

            // Crea una lista de SelectListItem, donde cada uno tiene el nombre del activo como texto
            // y el ID del activo como valor.
            ViewBag.Activos = activos.Select(a => new SelectListItem
            {
                Text = a.nombre,
                Value = a.valor.ToString()
            });
            /*ViewBag.Vulnerabilidades = vulner.Select(b => new SelectListItem
            {
                Text = b.nombreVulnerabilidad,
                Value = b.cvss.ToString()
            });
            ViewBag.Amenazas = amen.Select(c => new SelectListItem
            {
                Text = c.nombreAmenaza,
                Value = c.valor.ToString()
            });*/
            return View();
        }

        // POST: Calculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,valorActivo,valorVulnerabilidad,valorAmenaza,total")] Calculos calculos)
        {
            if (ModelState.IsValid)
            {
                calculos.total = calculos.valorVulnerabilidad * calculos.valorActivo * calculos.valorAmenaza;
                _context.Add(calculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculos);
        }

        // GET: Calculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calculos == null)
            {
                return NotFound();
            }

            var calculos = await _context.Calculos.FindAsync(id);
            if (calculos == null)
            {
                return NotFound();
            }
            return View(calculos);
        }

        // POST: Calculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,valorActivo,valorVulnerabilidad,valorAmenaza,total")] Calculos calculos)
        {
            if (id != calculos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculosExists(calculos.id))
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
            return View(calculos);
        }

        // GET: Calculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calculos == null)
            {
                return NotFound();
            }

            var calculos = await _context.Calculos
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculos == null)
            {
                return NotFound();
            }

            return View(calculos);
        }

        // POST: Calculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calculos == null)
            {
                return Problem("Entity set 'ProyectoSeguridadContext.Calculos'  is null.");
            }
            var calculos = await _context.Calculos.FindAsync(id);
            if (calculos != null)
            {
                _context.Calculos.Remove(calculos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculosExists(int id)
        {
          return (_context.Calculos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
