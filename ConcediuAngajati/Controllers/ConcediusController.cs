using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcediuAngajati.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConcediuAngajati.Controllers
{
    [Authorize(Roles = "Resurse umane, Rol operational")]
    public class ConcediusController : Controller
    {
        private readonly ConcediuAngajatiContext _context;

        public ConcediusController(ConcediuAngajatiContext context)
        {
            _context = context;
        }

        // GET: Concedius
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concedii.ToListAsync());
        }

        // GET: Concedius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concediu = await _context.Concedii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concediu == null)
            {
                return NotFound();
            }

            return View(concediu);
        }

        // GET: Concedius/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concedius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipConcediu,NrZile")] Concediu concediu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concediu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concediu);
        }

        // GET: Concedius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concediu = await _context.Concedii.FindAsync(id);
            if (concediu == null)
            {
                return NotFound();
            }
            return View(concediu);
        }

        // POST: Concedius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipConcediu,NrZile")] Concediu concediu)
        {
            if (id != concediu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concediu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcediuExists(concediu.Id))
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
            return View(concediu);
        }

        // GET: Concedius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concediu = await _context.Concedii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concediu == null)
            {
                return NotFound();
            }

            return View(concediu);
        }

        // POST: Concedius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concediu = await _context.Concedii.FindAsync(id);
            _context.Concedii.Remove(concediu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcediuExists(int id)
        {
            return _context.Concedii.Any(e => e.Id == id);
        }
    }
}
