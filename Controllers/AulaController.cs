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
    public class AulaController : Controller
    {
        private readonly AppDbContext _context;

        public AulaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Aula
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Aulas.Include(a => a.Grado);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Aula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.Grado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // GET: Aula/Create
               public IActionResult Create()
        {
            // Concatenar Nombre y Sección para mostrar en el dropdown
            var grados = _context.Grados.Select(g => new
            {
                Id = g.Id,
                NombreCompleto = g.Nombre + " - " + g.Seccion // Concatenamos Nombre y Sección
            }).ToList();

            ViewBag.GradoId = new SelectList(grados, "Id", "NombreCompleto");
            return View();
        }

        // POST: Aulas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recargar la lista de grados en caso de fallo de validación
            var grados = _context.Grados.Select(g => new
            {
                Id = g.Id,
                NombreCompleto = g.Nombre + " - " + g.Seccion
            }).ToList();

            ViewBag.GradoId = new SelectList(grados, "Id", "NombreCompleto", aula.GradoId);
            return View(aula);
        }


        // GET: Aula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Id", aula.GradoId);
            return View(aula);
        }

        // POST: Aula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Seccion,GradoId")] Aula aula)
        {
            if (id != aula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id))
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
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Id", aula.GradoId);
            return View(aula);
        }

        // GET: Aula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.Grado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);
            if (aula != null)
            {
                _context.Aulas.Remove(aula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.Id == id);
        }
    }
}
