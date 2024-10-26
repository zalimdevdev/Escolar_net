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
    public class PeriodoController : Controller
    {
        private readonly AppDbContext _context;

        public PeriodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Periodo
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Periodos.Include(p => p.AñoEscolar);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Periodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .Include(p => p.AñoEscolar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

// GET: Periodo/Create
public IActionResult Create()
{
    ViewData["AñoEscolarId"] = new SelectList(_context.AñoEscolars, "Id", "NombreAño");
    return View();
}

        // POST: Periodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInicio,FechaFin,AñoEscolarId")] Periodo periodo)
{
    if (ModelState.IsValid)
    {
        _context.Add(periodo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    ViewData["AñoEscolarId"] = new SelectList(_context.AñoEscolars, "Id", "NombreAño", periodo.AñoEscolarId);
    return View(periodo);
}

 // GET: Periodo/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var periodo = await _context.Periodos.FindAsync(id);
    if (periodo == null)
    {
        return NotFound();
    }

    ViewData["AñoEscolarId"] = new SelectList(_context.AñoEscolars, "Id", "NombreAño", periodo.AñoEscolarId);
    return View(periodo);
}

        // POST: Periodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInicio,FechaFin,AñoEscolarId")] Periodo periodo)
{
    if (id != periodo.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(periodo);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeriodoExists(periodo.Id))
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

    ViewData["AñoEscolarId"] = new SelectList(_context.AñoEscolars, "Id", "NombreAño", periodo.AñoEscolarId);
    return View(periodo);
}

        // GET: Periodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodos
                .Include(p => p.AñoEscolar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo != null)
            {
                _context.Periodos.Remove(periodo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoExists(int id)
        {
            return _context.Periodos.Any(e => e.Id == id);
        }
    }
}
