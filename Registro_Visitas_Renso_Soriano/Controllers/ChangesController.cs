using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registro_Visitas_Renso_Soriano.Data;

namespace Registro_Visitas_Renso_Soriano.Controllers
{
    public class ChangesController : Controller
    {
        private readonly AppDbContext _context;

        public ChangesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Changes
        public async Task<IActionResult> Index(string search = null)
        {
            ViewData[nameof(search)] = search;
            if (string.IsNullOrEmpty(search))
            {
                return View(await _context.Changes.ToListAsync());
            }
            else
            {
                return View(await _context.Changes
                    .Where(a => a.ChangesNames.Contains(search)).
                    ToListAsync());
            }
        }

        // GET: Changes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Changes == null)
            {
                return NotFound();
            }

            var changes = await _context.Changes
                .FirstOrDefaultAsync(m => m.IdChanges == id);
            if (changes == null)
            {
                return NotFound();
            }

            return View(changes);
        }

        // GET: Changes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChanges,ChangesNames")] Changes changes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(changes);
        }

        // GET: Changes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Changes == null)
            {
                return NotFound();
            }

            var changes = await _context.Changes.FindAsync(id);
            if (changes == null)
            {
                return NotFound();
            }
            return View(changes);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChanges,ChangesNames")] Changes changes)
        {
            if (id != changes.IdChanges)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(changes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangesExists(changes.IdChanges))
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
            return View(changes);
        }

        // GET: Changes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Changes == null)
            {
                return NotFound();
            }

            var changes = await _context.Changes
                .FirstOrDefaultAsync(m => m.IdChanges == id);
            if (changes == null)
            {
                return NotFound();
            }

            return View(changes);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Changes == null)
            {
                return Problem("Entity set 'AppDbContext.Changes'  is null.");
            }
            var changes = await _context.Changes.FindAsync(id);
            if (changes != null)
            {
                _context.Changes.Remove(changes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangesExists(int id)
        {
          return (_context.Changes?.Any(e => e.IdChanges == id)).GetValueOrDefault();
        }
    }
}
