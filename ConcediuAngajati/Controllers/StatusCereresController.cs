using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcediuAngajati.Models;

namespace ConcediuAngajati.Controllers
{
    public class StatusCereresController : Controller
    {
        private readonly ConcediuAngajatiContext _context;

        public StatusCereresController(ConcediuAngajatiContext context)
        {
            _context = context;
        }

        // GET: StatusCereres
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusCereri.ToListAsync());
        }

        // GET: StatusCereres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCerere = await _context.StatusCereri
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (statusCerere == null)
            {
                return NotFound();
            }

            return View(statusCerere);
        }

        // GET: StatusCereres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusCereres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,Status,Descriere")] StatusCerere statusCerere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusCerere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusCerere);
        }

        // GET: StatusCereres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCerere = await _context.StatusCereri.FindAsync(id);
            if (statusCerere == null)
            {
                return NotFound();
            }
            return View(statusCerere);
        }

        // POST: StatusCereres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,Status,Descriere")] StatusCerere statusCerere)
        {
            if (id != statusCerere.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusCerere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusCerereExists(statusCerere.StatusId))
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
            return View(statusCerere);
        }

        // GET: StatusCereres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCerere = await _context.StatusCereri
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (statusCerere == null)
            {
                return NotFound();
            }

            return View(statusCerere);
        }

        // POST: StatusCereres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusCerere = await _context.StatusCereri.FindAsync(id);
            _context.StatusCereri.Remove(statusCerere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusCerereExists(int id)
        {
            return _context.StatusCereri.Any(e => e.StatusId == id);
        }
    }
}
