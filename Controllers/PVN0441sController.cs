using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamVanNhan441.Models;

namespace PhamVanNhan441.Controllers
{
    public class PVN0441sController : Controller
    {
        private readonly PhamVanNhan441DbContext _context;

        public PVN0441sController(PhamVanNhan441DbContext context)
        {
            _context = context;
        }

        // GET: PVN0441s
        public async Task<IActionResult> Index()
        {
            return View(await _context.PVN0441.ToListAsync());
        }

        // GET: PVN0441s/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pVN0441 = await _context.PVN0441
                .FirstOrDefaultAsync(m => m.PVNID == id);
            if (pVN0441 == null)
            {
                return NotFound();
            }

            return View(pVN0441);
        }

        // GET: PVN0441s/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PVN0441s/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PVNID,PVNName,PVNGender")] PVN0441 pVN0441)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pVN0441);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pVN0441);
        }

        // GET: PVN0441s/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pVN0441 = await _context.PVN0441.FindAsync(id);
            if (pVN0441 == null)
            {
                return NotFound();
            }
            return View(pVN0441);
        }

        // POST: PVN0441s/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PVNID,PVNName,PVNGender")] PVN0441 pVN0441)
        {
            if (id != pVN0441.PVNID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pVN0441);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PVN0441Exists(pVN0441.PVNID))
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
            return View(pVN0441);
        }

        // GET: PVN0441s/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pVN0441 = await _context.PVN0441
                .FirstOrDefaultAsync(m => m.PVNID == id);
            if (pVN0441 == null)
            {
                return NotFound();
            }

            return View(pVN0441);
        }

        // POST: PVN0441s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pVN0441 = await _context.PVN0441.FindAsync(id);
            _context.PVN0441.Remove(pVN0441);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PVN0441Exists(string id)
        {
            return _context.PVN0441.Any(e => e.PVNID == id);
        }
    }
}
