using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NesrineDziri.Data;
using NesrineDziri.Models;

namespace NesrineDziri.Controllers
{
    public class Perfumery_StoreController : Controller
    {
        private readonly NesrineDziriContext _context;

        public Perfumery_StoreController(NesrineDziriContext context)
        {
            _context = context;
        }

        // GET: Perfumery_Store
        public async Task<IActionResult> Index()
        {
              return _context.Perfumery_Store != null ? 
                          View(await _context.Perfumery_Store.ToListAsync()) :
                          Problem("Entity set 'NesrineDziriContext.Perfumery_Store'  is null.");
        }


        public ActionResult Perfumery_StoreAndTheirMakeUps()
        {
            var makeUps= _context.MakeUp.ToList();
            return View(_context.Perfumery_Store.ToList());
        }


        // GET: Perfumery_Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfumery_Store == null)
            {
                return NotFound();
            }

            var perfumery_Store = await _context.Perfumery_Store
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfumery_Store == null)
            {
                return NotFound();
            }

            return View(perfumery_Store);
        }

        // GET: Perfumery_Store/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfumery_Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Perfumery_Store perfumery_Store)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfumery_Store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfumery_Store);
        }

        // GET: Perfumery_Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfumery_Store == null)
            {
                return NotFound();
            }

            var perfumery_Store = await _context.Perfumery_Store.FindAsync(id);
            if (perfumery_Store == null)
            {
                return NotFound();
            }
            return View(perfumery_Store);
        }

        // POST: Perfumery_Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Perfumery_Store perfumery_Store)
        {
            if (id != perfumery_Store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfumery_Store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Perfumery_StoreExists(perfumery_Store.Id))
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
            return View(perfumery_Store);
        }

        // GET: Perfumery_Store/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfumery_Store == null)
            {
                return NotFound();
            }

            var perfumery_Store = await _context.Perfumery_Store
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfumery_Store == null)
            {
                return NotFound();
            }

            return View(perfumery_Store);
        }

        // POST: Perfumery_Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfumery_Store == null)
            {
                return Problem("Entity set 'NesrineDziriContext.Perfumery_Store'  is null.");
            }
            var perfumery_Store = await _context.Perfumery_Store.FindAsync(id);
            if (perfumery_Store != null)
            {
                _context.Perfumery_Store.Remove(perfumery_Store);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Perfumery_StoreExists(int id)
        {
          return (_context.Perfumery_Store?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
