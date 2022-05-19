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
    public class VisitsHistoriesController : Controller
    {
        private readonly AppDbContext _context;

        public VisitsHistoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VisitsHistories sirve para realizar la busqueda de info en la app
        public async Task<IActionResult> Index(string search = null)
        {
            ViewData[nameof(search)] = search;

            if (string.IsNullOrEmpty(search))
            {
                var appDbContext = _context.VisitsHistories.
                    Include(v => v.Date)
                   .Include(v => v.Subject);

                return View(await appDbContext.ToListAsync());

            }
            else
            {
                var appDbContext = _context.VisitsHistories
                   .Include(v => v.Date)
                   .Include(v => v.Subject)
              .Where(v => v.Subject.Contains(search));

                return View(await appDbContext.ToListAsync());

            }
        }

        // GET: VisitsHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VisitsHistories == null)
            {
                return NotFound();
            }

            var visitsHistory = await _context.VisitsHistories
                .Include(v => v.Visitors)
                .FirstOrDefaultAsync(m => m.VisitsId == id);
            if (visitsHistory == null)
            {
                return NotFound();
            }

            return View(visitsHistory);
        }

        // GET: VisitsHistories sirve para realizar la insertar de info en la app
        public IActionResult Create()
        {
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name");
            return View();
        }

        // POST: VisitsHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitsId,VisitorId,Subject,Date,DateIncome,DateDeparture")] VisitsHistory visitsHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitsHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name", visitsHistory.VisitorId);
            return View(visitsHistory);
        }

        // GET: VisitsHistories sirve para realizar la editar de info en la app
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VisitsHistories == null)
            {
                return NotFound();
            }

            var visitsHistory = await _context.VisitsHistories.FindAsync(id);
            if (visitsHistory == null)
            {
                return NotFound();
            }
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name", visitsHistory.VisitorId);
            return View(visitsHistory);
        }

        // POST: VisitsHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitsId,VisitorId,Subject,Date,DateIncome,DateDeparture")] VisitsHistory visitsHistory)
        {
            if (id != visitsHistory.VisitsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitsHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitsHistoryExists(visitsHistory.VisitsId))
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
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name", visitsHistory.VisitorId);
            return View(visitsHistory);
        }
        public async Task<IActionResult> View(int id, [Bind("DateDeparture")] VisitsHistory visitsHistory)
        {
            if (id != visitsHistory.VisitsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitsHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitsHistoryExists(visitsHistory.VisitsId))
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
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name", visitsHistory.VisitorId);
            return View(visitsHistory);
        }

        // GET: VisitsHistories sirve para realizar la borrar de info en la app
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VisitsHistories == null)
            {
                return NotFound();
            }

            var visitsHistory = await _context.VisitsHistories
                .Include(v => v.Visitors)
                .FirstOrDefaultAsync(m => m.VisitsId == id);
            if (visitsHistory == null)
            {
                return NotFound();
            }

            return View(visitsHistory);
        }

        // POST: VisitsHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VisitsHistories == null)
            {
                return Problem("Entity set 'AppDbContext.VisitsHistories'  is null.");
            }
            var visitsHistory = await _context.VisitsHistories.FindAsync(id);
            if (visitsHistory != null)
            {
                _context.VisitsHistories.Remove(visitsHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitsHistoryExists(int id)
        {
          return (_context.VisitsHistories?.Any(e => e.VisitsId == id)).GetValueOrDefault();
        }
    }
}
