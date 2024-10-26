using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escolar_net.Models;

namespace Escolar_net.Controllers
{
    public class ClaseController : Controller
    {
        private readonly AppDbContext _context;

        public ClaseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Clase
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Clases.Include(c => c.Aula).Include(c => c.Grado).Include(c => c.Profesor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Clase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Aula)
                .Include(c => c.Grado)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clase/Create
 // GET: Clases/Create
    public IActionResult Create()
    {
        // Poblar ViewBags con los datos necesarios para los dropdowns
        ViewBag.ProfesorId = new SelectList(_context.Profesors, "Id", "Nombre"); // Asumiendo que Profesor tiene una propiedad Nombre
        ViewBag.AulaId = new SelectList(_context.Aulas, "Id", "Nombre");
        ViewBag.GradoId = new SelectList(_context.Grados, "Id", "Nombre");

        return View();
    }

    // POST: Clases/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,HoraInicio,HoraFin,ProfesorId,AulaId,GradoId")] Clase clase)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Si la creación falla, volver a poblar los ViewBags
        ViewBag.ProfesorId = new SelectList(_context.Profesors, "Id", "Nombre", clase.ProfesorId);
        ViewBag.AulaId = new SelectList(_context.Aulas, "Id", "Nombre", clase.AulaId);
        ViewBag.GradoId = new SelectList(_context.Grados, "Id", "Nombre", clase.GradoId);

        return View(clase);
    }

        // GET: Clase/Edit/5
 // GET: Clases/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Clases == null)
        {
            return NotFound();
        }

        var clase = await _context.Clases.FindAsync(id);
        if (clase == null)
        {
            return NotFound();
        }

        // Poblar los ViewBag con los nombres para los dropdowns
        ViewBag.ProfesorId = new SelectList(_context.Profesors, "Id", "Nombre", clase.ProfesorId);
        ViewBag.AulaId = new SelectList(_context.Aulas, "Id", "Nombre", clase.AulaId);
        ViewBag.GradoId = new SelectList(_context.Grados, "Id", "Nombre", clase.GradoId);

        return View(clase);
    }

    // POST: Clases/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,HoraInicio,HoraFin,ProfesorId,AulaId,GradoId")] Clase clase)
    {
        if (id != clase.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(clase);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseExists(clase.Id))
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

        // Si la edición falla, volver a poblar los ViewBag
        ViewBag.ProfesorId = new SelectList(_context.Profesors, "Id", "Nombre", clase.ProfesorId);
        ViewBag.AulaId = new SelectList(_context.Aulas, "Id", "Nombre", clase.AulaId);
        ViewBag.GradoId = new SelectList(_context.Grados, "Id", "Nombre", clase.GradoId);

        return View(clase);
    }

        // GET: Clase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Aula)
                .Include(c => c.Grado)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.Id == id);
        }
    }
}
