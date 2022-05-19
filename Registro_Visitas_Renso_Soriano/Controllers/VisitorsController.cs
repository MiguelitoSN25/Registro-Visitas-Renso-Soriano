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
    public class VisitorsController : Controller
    {
        private readonly AppDbContext _context;

        public VisitorsController(AppDbContext context)
        {
            _context = context;
        }
        //Metodo que busca si utiliza los valores suministrados para realizar la busqueda

        // GET: Visitors
        public async Task<IActionResult> Index(string search = null)
        {
             ViewData[nameof(search)] = search;
            if (string.IsNullOrEmpty(search))
            {
                return View(await _context.Visitors.ToListAsync());
            }
            else
            {
                return View(await _context.Visitors
                    .Where(a => a.Name.Contains(search)).
                    ToListAsync());
            }
        }

        //Metodo que ve los detalles de los valores suministrados para realizar la busqueda
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitors = await _context.Visitors
                .FirstOrDefaultAsync(m => m.VisitorId == id);
            if (visitors == null)
            {
                return NotFound();
            }

            return View(visitors);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            return View();
        }
        //Metodo que inserta los datos a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitorId,Name,LastName,Last_Date_Register")] Visitors visitors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitors);
        }

        //Metodo que actualiza  los datos a la base de datos
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitors = await _context.Visitors.FindAsync(id);
            if (visitors == null)
            {
                return NotFound();
            }
            return View(visitors);
        }

        //Metodo que inserta los datos a la base de datos

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitorId,Name,LastName,Last_Date_Register")] Visitors visitors)
        {
            if (id != visitors.VisitorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorsExists(visitors.VisitorId))
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
            return View(visitors);
        }

        //Metodo que borra los datos de la base de datos
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitors = await _context.Visitors
                .FirstOrDefaultAsync(m => m.VisitorId == id);
            if (visitors == null)
            {
                return NotFound();
            }

            return View(visitors);
        }

        //Metodo que borra los datos de la base de datos

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Visitors == null)
            {
                return Problem("Entity set 'AppDbContext.Visitors'  is null.");
            }
            var visitors = await _context.Visitors.FindAsync(id);
            if (visitors != null)
            {
                _context.Visitors.Remove(visitors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorsExists(int id)
        {
          return (_context.Visitors?.Any(e => e.VisitorId == id)).GetValueOrDefault();
        }
    }
}
