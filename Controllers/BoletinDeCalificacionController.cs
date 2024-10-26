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
    public class BoletinDeCalificacionController : Controller
    {
        private readonly AppDbContext _context;

        public BoletinDeCalificacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BoletinDeCalificacion
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BoletinDeCalificacions.Include(b => b.Estudiante).Include(b => b.Periodo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BoletinDeCalificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletinDeCalificacion = await _context.BoletinDeCalificacions
                .Include(b => b.Estudiante)
                .Include(b => b.Periodo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boletinDeCalificacion == null)
            {
                return NotFound();
            }

            return View(boletinDeCalificacion);
        }

        // GET: BoletinDeCalificacion/Create
     // GET: BoletinDeCalificacion/Create
public IActionResult Create()
{
    ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre");
    ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Nombre");
    return View();
}

// POST: BoletinDeCalificacion/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Fecha,EstudianteId,PeriodoId,FechaEmision")] BoletinDeCalificacion boletinDeCalificacion)
{
    if (ModelState.IsValid)
    {
        _context.Add(boletinDeCalificacion);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", boletinDeCalificacion.EstudianteId);
    ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Nombre", boletinDeCalificacion.PeriodoId);
    return View(boletinDeCalificacion);
}

// GET: BoletinDeCalificacion/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var boletinDeCalificacion = await _context.BoletinDeCalificacions
        .Include(b => b.Notas)
        .ThenInclude(n => n.Materia)
        .FirstOrDefaultAsync(m => m.Id == id);
    
    if (boletinDeCalificacion == null)
    {
        return NotFound();
    }
    
    ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", boletinDeCalificacion.EstudianteId);
    ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Nombre", boletinDeCalificacion.PeriodoId);
    
    return View(boletinDeCalificacion);
}

// POST: BoletinDeCalificacion/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,EstudianteId,PeriodoId,FechaEmision")] BoletinDeCalificacion boletinDeCalificacion)
{
    if (id != boletinDeCalificacion.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(boletinDeCalificacion);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BoletinDeCalificacionExists(boletinDeCalificacion.Id))
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

    ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", boletinDeCalificacion.EstudianteId);
    ViewData["PeriodoId"] = new SelectList(_context.Periodos, "Id", "Nombre", boletinDeCalificacion.PeriodoId);
    return View(boletinDeCalificacion);
}


        // GET: BoletinDeCalificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletinDeCalificacion = await _context.BoletinDeCalificacions
                .Include(b => b.Estudiante)
                .Include(b => b.Periodo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boletinDeCalificacion == null)
            {
                return NotFound();
            }

            return View(boletinDeCalificacion);
        }

        // POST: BoletinDeCalificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boletinDeCalificacion = await _context.BoletinDeCalificacions.FindAsync(id);
            if (boletinDeCalificacion != null)
            {
                _context.BoletinDeCalificacions.Remove(boletinDeCalificacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletinDeCalificacionExists(int id)
        {
            return _context.BoletinDeCalificacions.Any(e => e.Id == id);
        }
    }
}
