using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDocker.Data;
using MVCDocker.Models;

namespace MVCDocker.Controllers
{
    public class PlanetsController : Controller
    {
        private readonly MvcDockerContext _context;

        public PlanetsController(MvcDockerContext context)
        {
            _context = context;
        }

        // GET: Planets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planets.ToListAsync());
        }

        // GET: Planets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planets = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planets == null)
            {
                return NotFound();
            }

            return View(planets);
        }

        // GET: Planets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Planets planets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planets);
        }

        // GET: Planets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planets = await _context.Planets.FindAsync(id);
            if (planets == null)
            {
                return NotFound();
            }
            return View(planets);
        }

        // POST: Planets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Planets planets)
        {
            if (id != planets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetsExists(planets.Id))
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
            return View(planets);
        }

        // GET: Planets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planets = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planets == null)
            {
                return NotFound();
            }

            return View(planets);
        }

        // POST: Planets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planets = await _context.Planets.FindAsync(id);
            _context.Planets.Remove(planets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetsExists(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
