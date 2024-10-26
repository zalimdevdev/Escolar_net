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
    public class AñoEscolarController : Controller
    {
        private readonly AppDbContext _context;

        public AñoEscolarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AñoEscolar
        public async Task<IActionResult> Index()
        {
            return View(await _context.AñoEscolars.ToListAsync());
        }

        // GET: AñoEscolar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var añoEscolar = await _context.AñoEscolars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (añoEscolar == null)
            {
                return NotFound();
            }

            return View(añoEscolar);
        }

        // GET: AñoEscolar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AñoEscolar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaInicio,FechaFin,Estado,NombreAño")] AñoEscolar añoEscolar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(añoEscolar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(añoEscolar);
        }

        // GET: AñoEscolar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var añoEscolar = await _context.AñoEscolars.FindAsync(id);
            if (añoEscolar == null)
            {
                return NotFound();
            }
            return View(añoEscolar);
        }

        // POST: AñoEscolar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicio,FechaFin,Estado,NombreAño")] AñoEscolar añoEscolar)
        {
            if (id != añoEscolar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(añoEscolar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AñoEscolarExists(añoEscolar.Id))
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
            return View(añoEscolar);
        }

        // GET: AñoEscolar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var añoEscolar = await _context.AñoEscolars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (añoEscolar == null)
            {
                return NotFound();
            }

            return View(añoEscolar);
        }

        // POST: AñoEscolar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var añoEscolar = await _context.AñoEscolars.FindAsync(id);
            if (añoEscolar != null)
            {
                _context.AñoEscolars.Remove(añoEscolar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AñoEscolarExists(int id)
        {
            return _context.AñoEscolars.Any(e => e.Id == id);
        }
    }
}
