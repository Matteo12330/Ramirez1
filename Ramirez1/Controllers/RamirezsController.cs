using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ramirez1.Data;
using Ramirez1.Models;

namespace Ramirez1.Controllers
{
    public class RamirezsController : Controller
    {
        private readonly Ramirez1Context _context;

        public RamirezsController(Ramirez1Context context)
        {
            _context = context;
        }

        // GET: Ramirezs
        public async Task<IActionResult> Index()
        {
            var ramirez1Context = _context.Ramirez.Include(r => r.Carrera);
            return View(await ramirez1Context.ToListAsync());
        }

        // GET: Ramirezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramirez = await _context.Ramirez
                .Include(r => r.Carrera)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ramirez == null)
            {
                return NotFound();
            }

            return View(ramirez);
        }

        // GET: Ramirezs/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id");
            return View();
        }

        // POST: Ramirezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Edad,CorreoElectronico,EsEstudiante,CarreraId")] Ramirez ramirez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ramirez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", ramirez.CarreraId);
            return View(ramirez);
        }

        // GET: Ramirezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramirez = await _context.Ramirez.FindAsync(id);
            if (ramirez == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", ramirez.CarreraId);
            return View(ramirez);
        }

        // POST: Ramirezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Edad,CorreoElectronico,EsEstudiante,CarreraId")] Ramirez ramirez)
        {
            if (id != ramirez.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ramirez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamirezExists(ramirez.ID))
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
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", ramirez.CarreraId);
            return View(ramirez);
        }

        // GET: Ramirezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ramirez = await _context.Ramirez
                .Include(r => r.Carrera)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ramirez == null)
            {
                return NotFound();
            }

            return View(ramirez);
        }

        // POST: Ramirezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ramirez = await _context.Ramirez.FindAsync(id);
            if (ramirez != null)
            {
                _context.Ramirez.Remove(ramirez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamirezExists(int id)
        {
            return _context.Ramirez.Any(e => e.ID == id);
        }
    }
}
