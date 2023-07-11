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
    public class ControlsController : Controller
    {
        private readonly ProyectoSeguridadContext _context;

        public ControlsController(ProyectoSeguridadContext context)
        {
            _context = context;
        }
        public ActionResult CrearControl()
        {
            // Obtiene todos los Activos de la base de datos.
            var activos = _context.Activo.ToList();

            // Pasa los Activos a la vista.
            return View(activos);
        }
        // GET: Controls
        public async Task<IActionResult> Index()
        {
            return _context.Control != null ?
                        View(await _context.Control.ToListAsync()) :
                        Problem("Entity set 'ProyectoSeguridadContext.Control'  is null.");
        }
        /*public ActionResult ObtenerNombresActivos()
        {
            List<string> nombresActivos = new List<string>();

            // Obtener todos los registros de la clase Activos
            List<Activo> listaActivos = db.Activo.ToList();

            // Recorrer la lista de Activos y obtener los nombres
            foreach (var activo in listaActivos)
            {
                nombresActivos.Add(activo.nombre);
            }

            // Devolver los nombres de los Activos como resultado
            return Json(nombresActivos, JsonRequestBehavior.AllowGet);
        }*/
        // GET: Controls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control
                .FirstOrDefaultAsync(m => m.id == id);
            if (control == null)
            {
                return NotFound();
            }

            return View(control);
        }

        // GET: Controls/Create
        public IActionResult Create()
        {
            // Carga los activos desde la base de datos
            var activos = _context.Activo.ToList();

            // Crea una lista de SelectListItem, donde cada uno tiene el nombre del activo como texto
            // y el ID del activo como valor.
            ViewBag.ActivoId = activos.Select(a => new SelectListItem
            {
                Text = a.nombre,
                Value = a.id.ToString()
            });

            return View();
        }

        // POST: Controls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombreControl,descripcionControl,efectividad,ActivoId")] Control control)
        {
            if (ModelState.IsValid)
            {
                _context.Add(control);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(control);
        }

        // GET: Controls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control.FindAsync(id);
            if (control == null)
            {
                return NotFound();
            }
            return View(control);
        }

        // POST: Controls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreControl,descripcionControl,efectividad, ActivoId")] Control control)
        {
            if (id != control.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(control);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlExists(control.id))
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
            return View(control);
        }

        // GET: Controls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control
                .FirstOrDefaultAsync(m => m.id == id);
            if (control == null)
            {
                return NotFound();
            }

            return View(control);
        }

        // POST: Controls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Control == null)
            {
                return Problem("Entity set 'ProyectoSeguridadContext.Control'  is null.");
            }
            var control = await _context.Control.FindAsync(id);
            if (control != null)
            {
                _context.Control.Remove(control);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlExists(int id)
        {
            return (_context.Control?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}