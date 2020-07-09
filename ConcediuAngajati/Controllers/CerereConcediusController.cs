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
    [Authorize(Roles = "Manager, Rol operational")]
    public class CerereConcediusController : Controller
    {
        private readonly ConcediuAngajatiContext _context;

        public CerereConcediusController(ConcediuAngajatiContext context)
        {
            _context = context;
        }

        // GET: CerereConcedius
        public async Task<IActionResult> Index()
        {
            var concediuAngajatiContext = _context.CereriConcediu.Include(c => c.Angajat).Include(c => c.StatusCerere);
            return View(await concediuAngajatiContext.ToListAsync());
        }

        // GET: CerereConcedius/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerereConcediu = await _context.CereriConcediu
                .Include(c => c.Angajat)
                .Include(c => c.StatusCerere)
                .FirstOrDefaultAsync(m => m.CerereId == id);
            if (cerereConcediu == null)
            {
                return NotFound();
            }

            return View(cerereConcediu);
        }

        // GET: CerereConcedius/Create
        public IActionResult Create()
        {
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId");
            ViewData["StatusCerereId"] = new SelectList(_context.StatusCereri, "StatusId", "StatusId");
            return View();
        }

        // POST: CerereConcedius/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CerereId,TipConcediu,Descriere,StartDate,EndDate,AngajatId")] CerereConcediu cerereConcediu)
        {
            if (ModelState.IsValid)
            {
                cerereConcediu.StatusCerereId = 1;
                _context.Add(cerereConcediu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", cerereConcediu.AngajatId);
            ViewData["StatusCerereId"] = new SelectList(_context.StatusCereri, "StatusId", "StatusId", cerereConcediu.StatusCerereId);
            return View(cerereConcediu);
        }

        // GET: CerereConcedius/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerereConcediu = await _context.CereriConcediu.FindAsync(id);
            if (cerereConcediu == null)
            {
                return NotFound();
            }
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", cerereConcediu.AngajatId);
            ViewData["StatusCerereId"] = new SelectList(_context.StatusCereri, "StatusId", "StatusId", cerereConcediu.StatusCerereId);
            return View(cerereConcediu);
        }

        // POST: CerereConcedius/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CerereId,TipConcediu,Descriere,StartDate,EndDate,StatusCerereId,AngajatId")] CerereConcediu cerereConcediu)
        {
            if (id != cerereConcediu.CerereId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cerereConcediu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CerereConcediuExists(cerereConcediu.CerereId))
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
            ViewData["AngajatId"] = new SelectList(_context.Angajati, "AngajatId", "AngajatId", cerereConcediu.AngajatId);
            ViewData["StatusCerereId"] = new SelectList(_context.StatusCereri, "StatusId", "StatusId", cerereConcediu.StatusCerereId);
            return View(cerereConcediu);
        }

        // GET: CerereConcedius/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cerereConcediu = await _context.CereriConcediu
                .Include(c => c.Angajat)
                .Include(c => c.StatusCerere)
                .FirstOrDefaultAsync(m => m.CerereId == id);
            if (cerereConcediu == null)
            {
                return NotFound();
            }

            return View(cerereConcediu);
        }

        // POST: CerereConcedius/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cerereConcediu = await _context.CereriConcediu.FindAsync(id);
            _context.CereriConcediu.Remove(cerereConcediu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Accept(int id)
        {
            var cerereConcediu = await _context.CereriConcediu.FindAsync(id);
            var concediu = await _context.Concedii.FindAsync(cerereConcediu.TipConcediu);

            var ac = await _context.AngajatiConcedii.FindAsync(cerereConcediu.AngajatId);
            if (ac == null)
            {
                ac = new AngajatConcediu();
                ac.ZileConcediuDisponibile = concediu.NrZile;
            }

            var angajat = await _context.Angajati.FindAsync(cerereConcediu.AngajatId);

            var nrZileSplocitate = cerereConcediu.EndDate.Subtract(cerereConcediu.StartDate).TotalDays;
            ac.ZileConcediuUtilizate += Convert.ToInt32(nrZileSplocitate);
            ac.ZileConcediuDisponibile = concediu.NrZile - Convert.ToInt32(nrZileSplocitate);

            if (ac.ZileConcediuUtilizate <= concediu.NrZile)
            {
                angajat.InConcediu = true;
                cerereConcediu.StatusCerere = _context.StatusCereri.Find(4);
                ac.AngajatId = cerereConcediu.AngajatId;
                ac.ConcediuId = cerereConcediu.TipConcediu;

                _context.Add(ac);
                await _context.SaveChangesAsync();
            }  else
            {
               cerereConcediu.StatusCerere = _context.StatusCereri.Find(3);
                await _context.SaveChangesAsync();
            }          

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int id)
        {
            var cerereConcediu = await _context.CereriConcediu.FindAsync(id);
            cerereConcediu.StatusCerere = _context.StatusCereri.Find(2);

            try
            {
                _context.Update(cerereConcediu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CerereConcediuExists(cerereConcediu.CerereId))
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

        public async Task<IActionResult> Close(int id)
        {
            var cerereConcediu = await _context.CereriConcediu.FindAsync(id);
            cerereConcediu.StatusCerere = _context.StatusCereri.Find(3);

            try
            {
                _context.Update(cerereConcediu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CerereConcediuExists(cerereConcediu.CerereId))
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

        private bool CerereConcediuExists(int id)
        {
            return _context.CereriConcediu.Any(e => e.CerereId == id);
        }


        //public async Task<IActionResult> Accept(int cerereId, int concediuId, int angajatId)
        //{
        //    var cerereConcediu = await _context.CereriConcediu.FindAsync(cerereId);
        //    var concediu = await _context.Concedii.FindAsync(concediuId);
        //    var ac = _context.AngajatiConcedii.Where(e => e.ConcediuId == concediuId && e.ConcediuId == concediuId).FirstOrDefault();
        //    if (ac == null)
        //    {
        //        ac = new AngajatConcediu();
        //        ac.ZileConcediuDisponibile = concediu.NrZile;
        //        ac.ZileConcediuUtilizate = 0;
        //    }

        //    var angajat = await _context.Angajati.FindAsync(angajatId);

        //    var nrZileSolicitate = cerereConcediu.EndDate.Subtract(cerereConcediu.StartDate).TotalDays;
        //    ac.ZileConcediuUtilizate += Convert.ToInt32(nrZileSolicitate);
        //    ac.ZileConcediuDisponibile -= Convert.ToInt32(nrZileSolicitate);

        //    if (ac.ZileConcediuUtilizate < concediu.NrZile)
        //    {
        //        angajat.InConcediu = true;
        //        cerereConcediu.StatusCerere = _context.StatusCereri.Find(4);
        //        //ac.AngajatId = cerereConcediu.AngajatId;
        //        //ac.ConcediuId = cerereConcediu.TipConcediu;

        //        _context.Add(ac);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        cerereConcediu.StatusCerere = _context.StatusCereri.Find(3);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
