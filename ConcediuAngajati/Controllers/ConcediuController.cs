using ConcediuAngajati.Models;
using ConcediuAngajati.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Controllers
{
    public class ConcediuController : Controller
    {
        private IConcediuService _concediuService;

        public ConcediuController(IConcediuService concediuService)
        {
            _concediuService = concediuService;
        }
        public async Task<IActionResult> Index()
        {
            var concediu = await _concediuService.GetAllConcediu();
            return View(concediu);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concediu = await _concediuService.GetConcediuById(id);
            if (concediu == null)
            {
                return NotFound();
            }

            return View(concediu);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, TipConcediu, NrZile, AngajatiConcedii")] Concediu concediu)
        {
            if (ModelState.IsValid)
            {
                await _concediuService.CreateConcediu(concediu);
                return RedirectToAction(nameof(Index));

            }
            return View(concediu);

        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concediu = await _concediuService.GetConcediuById(id);
            if (concediu == null)
            {
                return NotFound();
            }

            return View(concediu);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, TipConcediu, NrZile, AngajatiConcedii")]Concediu concediu)
        {
            if (id != concediu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _concediuService.UpdateConcediu(id, concediu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_concediuService.ConcediuExists(concediu.Id))
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

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concediu = await _concediuService.GetConcediuById(id);
            if (concediu == null)
            {
                return NotFound();
            }

            return View(concediu);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _concediuService.DeleteConcediu(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

