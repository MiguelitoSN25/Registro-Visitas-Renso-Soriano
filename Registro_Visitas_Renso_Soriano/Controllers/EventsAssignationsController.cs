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
    public class EventsAssignationsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsAssignationsController(AppDbContext context)
        {
            _context = context;
        }

        //Metodo que busca si utiliza los valores suministrados para realizar la busqueda
        public async Task<IActionResult> Index(string search = null)
        {
            ViewData[nameof(search)] = search;

            if (string.IsNullOrEmpty(search))
            {
                var appDbContext = _context.EventsAssignations.
                    Include(e => e.Events)
                    .Include(e => e.Visitors);
                return View(await appDbContext.ToListAsync());

            }
            else
            {
                var appDbContext = _context.EventsAssignations.
                    Include(e => e.Events)
                       .Include(e => e.Visitors)
                  .Where(a => a.Events.EventName.Contains(search)|| a.Visitors.Name.Contains(search));


                return View(await appDbContext.ToListAsync());

            }
        }

        // GET: EventsAssignations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventsAssignations == null)
            {
                return NotFound();
            }

            var eventsAssignation = await _context.EventsAssignations
                .Include(e => e.Events)
                .Include(e => e.Visitors)
                .FirstOrDefaultAsync(m => m.IdEventsAssignation == id);
            if (eventsAssignation == null)
            {
                return NotFound();
            }

            return View(eventsAssignation);
        }

        // GET: EventsAssignations/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName");
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name");
            return View();
        }

        // POST: EventsAssignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEventsAssignation,VisitorId,EventId,Date")] EventsAssignation eventsAssignation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventsAssignation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", eventsAssignation.EventId);
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "Name", eventsAssignation.VisitorId);
            return View(eventsAssignation);
        }

        // GET: EventsAssignations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventsAssignations == null)
            {
                return NotFound();
            }

            var eventsAssignation = await _context.EventsAssignations.FindAsync(id);
            if (eventsAssignation == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", eventsAssignation.EventId);
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "LastName", eventsAssignation.VisitorId);
            return View(eventsAssignation);
        }

        // POST: EventsAssignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEventsAssignation,VisitorId,EventId,Date")] EventsAssignation eventsAssignation)
        {
            if (id != eventsAssignation.IdEventsAssignation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsAssignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsAssignationExists(eventsAssignation.IdEventsAssignation))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId", eventsAssignation.EventId);
            ViewData["VisitorId"] = new SelectList(_context.Visitors, "VisitorId", "LastName", eventsAssignation.VisitorId);
            return View(eventsAssignation);
        }

        // GET: EventsAssignations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventsAssignations == null)
            {
                return NotFound();
            }

            var eventsAssignation = await _context.EventsAssignations
                .Include(e => e.Events)
                .Include(e => e.Visitors)
                .FirstOrDefaultAsync(m => m.IdEventsAssignation == id);
            if (eventsAssignation == null)
            {
                return NotFound();
            }

            return View(eventsAssignation);
        }

        // POST: EventsAssignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventsAssignations == null)
            {
                return Problem("Entity set 'AppDbContext.EventsAssignations'  is null.");
            }
            var eventsAssignation = await _context.EventsAssignations.FindAsync(id);
            if (eventsAssignation != null)
            {
                _context.EventsAssignations.Remove(eventsAssignation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsAssignationExists(int id)
        {
          return (_context.EventsAssignations?.Any(e => e.IdEventsAssignation == id)).GetValueOrDefault();
        }
    }
}
