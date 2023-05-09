using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NesrineDziri.Data;
using NesrineDziri.Models;

namespace NesrineDziri.Controllers
{
    public class MakeUpsController : Controller
    {
        private readonly NesrineDziriContext _context;

        public object Perfumery_Store { get; private set; }

        public MakeUpsController(NesrineDziriContext context)
        {
            _context = context;
        }

        // GET: MakeUps
        public async Task<IActionResult> Index()
        {
            var NesrineDziriContext = _context.MakeUp.Include(p => p.Perfumery_Store);
            return View(await NesrineDziriContext.ToListAsync());
        }


        public async Task<IActionResult> MakeUpAndTheirPerfumery_Store()
        {
            var NesrineDziriContext = _context.MakeUp.Include(p => p.Perfumery_Store);
            return View(await NesrineDziriContext.ToListAsync());
        }

        // action search by titre
        public IActionResult SearchByTitle(string s)
        {
            
            return View(_context.MakeUp.Where(m => m.Nom.Contains(s)).ToList());
        }

        // action search by name
        public IActionResult Search(string name)
        {

            var perfumery_Stores = _context.Perfumery_Store.ToList();
            ViewBag.Nom = perfumery_Stores.Select(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(name) && name != "All")
            {
                perfumery_Stores = perfumery_Stores.Where(m => m.Name == name).ToList();
            }

            if (name == "ALL")
            {
                perfumery_Stores = _context.Perfumery_Store.ToList();
            }
            
            return View("Search", perfumery_Stores);
        }

        // GET: MakeUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MakeUp == null)
            {
                return NotFound();
            }

            var makeUp = await _context.MakeUp
                .Include(m => m.Perfumery_Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makeUp == null)
            {
                return NotFound();
            }

            return View(makeUp);
        }

        // GET: MakeUps/Create
        public IActionResult Create()
        {
            ViewData["Perfumery_StoreId"] = new SelectList(_context.Perfumery_Store, "Id", "Id");
            return View();
        }

        // POST: MakeUps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Marque,Rating,MarqueUrl,ImageUrl,Perfumery_StoreId")] MakeUp makeUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(makeUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Perfumery_StoreId"] = new SelectList(_context.Perfumery_Store, "Id", "Id", makeUp.Perfumery_StoreId);
            return View(makeUp);
        }

        // GET: MakeUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MakeUp == null)
            {
                return NotFound();
            }

            var makeUp = await _context.MakeUp.FindAsync(id);
            if (makeUp == null)
            {
                return NotFound();
            }
            ViewData["Perfumery_StoreId"] = new SelectList(_context.Perfumery_Store, "Id", "Id", makeUp.Perfumery_StoreId);
            return View(makeUp);
        }

        // POST: MakeUps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Marque,Rating,MarqueUrl,ImageUrl,Perfumery_StoreId")] MakeUp makeUp)
        {
            if (id != makeUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makeUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeUpExists(makeUp.Id))
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
            ViewData["Perfumery_StoreId"] = new SelectList(_context.Perfumery_Store, "Id", "Id", makeUp.Perfumery_StoreId);
            return View(makeUp);
        }

        // GET: MakeUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MakeUp == null)
            {
                return NotFound();
            }

            var makeUp = await _context.MakeUp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makeUp == null)
            {
                return NotFound();
            }

            return View(makeUp);
        }

        // POST: MakeUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MakeUp == null)
            {
                return Problem("Entity set 'NesrineDziriContext.MakeUp'  is null.");
            }
            var makeUp = await _context.MakeUp.FindAsync(id);
            if (makeUp != null)
            {
                _context.MakeUp.Remove(makeUp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeUpExists(int id)
        {
          return (_context.MakeUp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
