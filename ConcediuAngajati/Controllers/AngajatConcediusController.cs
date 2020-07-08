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
    [Authorize(Roles = "Resurse umane, Rol operational, Manager")]
    public class AngajatConcediusController : Controller
    {
        private readonly ConcediuAngajatiContext _context;

        public AngajatConcediusController(ConcediuAngajatiContext context)
        {
            _context = context;
        }

        // GET: AngajatConcedius
        public async Task<IActionResult> Index()
        {
            var concediuAngajatiContext = _context.AngajatiConcedii.Include(a => a.Angajat).Include(a => a.Concediu);
            return View(await concediuAngajatiContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(int id)
        //{
        //    //var concediuAngajatiContext = _context.AngajatiConcedii.Include(a => a.Angajat).Include(a => a.Concediu);
        //    return View(await _context.AngajatiConcedii.Where(ac => ac.AngajatConcediuId == id).ToListAsync());
        //}

        // GET: AngajatConcedius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajatConcediu = await _context.AngajatiConcedii
                .Include(a => a.Angajat)
                .Include(a => a.Concediu)
                .FirstOrDefaultAsync(m => m.AngajatConcediuId == id);
            if (angajatConcediu == null)
            {
                return NotFound();
            }

            return View(angajatConcediu);
        }

        // GET: AngajatConcedius/Create
        public IActionResult Create()
        {
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId");
            ViewData["ConcediuId"] = new SelectList(_context.Concedii, "Id", "Id");
            return View();
        }

        // POST: AngajatConcedius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AngajatConcediuId,AngajatId,ConcediuId,ZileConcediuDisponibile,ZileConcediuUtilizate")] AngajatConcediu angajatConcediu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(angajatConcediu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", angajatConcediu.AngajatId);
            ViewData["ConcediuId"] = new SelectList(_context.Concedii, "Id", "Id", angajatConcediu.ConcediuId);
            return View(angajatConcediu);
        }

        // GET: AngajatConcedius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajatConcediu = await _context.AngajatiConcedii.FindAsync(id);
            if (angajatConcediu == null)
            {
                return NotFound();
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", angajatConcediu.AngajatId);
            ViewData["ConcediuId"] = new SelectList(_context.Concedii, "Id", "Id", angajatConcediu.ConcediuId);
            return View(angajatConcediu);
        }

        // POST: AngajatConcedius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AngajatConcediuId,AngajatId,ConcediuId,ZileConcediuDisponibile,ZileConcediuUtilizate")] AngajatConcediu angajatConcediu)
        {
            if (id != angajatConcediu.AngajatConcediuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(angajatConcediu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AngajatConcediuExists(angajatConcediu.AngajatConcediuId))
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
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", angajatConcediu.AngajatId);
            ViewData["ConcediuId"] = new SelectList(_context.Concedii, "Id", "Id", angajatConcediu.ConcediuId);
            return View(angajatConcediu);
        }

        // GET: AngajatConcedius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajatConcediu = await _context.AngajatiConcedii
                .Include(a => a.Angajat)
                .Include(a => a.Concediu)
                .FirstOrDefaultAsync(m => m.AngajatConcediuId == id);
            if (angajatConcediu == null)
            {
                return NotFound();
            }

            return View(angajatConcediu);
        }

        // POST: AngajatConcedius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var angajatConcediu = await _context.AngajatiConcedii.FindAsync(id);
            _context.AngajatiConcedii.Remove(angajatConcediu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatConcediuExists(int id)
        {
            return _context.AngajatiConcedii.Any(e => e.AngajatConcediuId == id);
        }
    }
}
