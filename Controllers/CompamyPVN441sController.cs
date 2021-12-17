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
    public class CompamyPVN441sController : Controller
    {
        private readonly PhamVanNhan441DbContext _context;
        StringProcessPVN441 strPro = new StringProcessPVN441();

        public CompamyPVN441sController(PhamVanNhan441DbContext context)
        {
            _context = context;
        }

        // GET: CompamyPVN441s
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyPVN441.ToListAsync());
        }

        // GET: CompamyPVN441s/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPVN441 = await _context.CompanyPVN441
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyPVN441 == null)
            {
                return NotFound();
            }

            return View(companyPVN441);
        }

        // GET: CompamyPVN441s/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompamyPVN441s/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName")] CompanyPVN441 companyPVN441)
        {
            if (ModelState.IsValid)
            {
                companyPVN441.CompanyName = strPro.LowerToUpper(companyPVN441.CompanyName);
                _context.Add(companyPVN441);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyPVN441);
        }

        // GET: CompamyPVN441s/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPVN441 = await _context.CompanyPVN441.FindAsync(id);
            if (companyPVN441 == null)
            {
                return NotFound();
            }
            return View(companyPVN441);
        }

        // POST: CompamyPVN441s/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CompanyId,CompanyName")] CompanyPVN441 companyPVN441)
        {
            if (id != companyPVN441.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyPVN441);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyPVN441Exists(companyPVN441.CompanyId))
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
            return View(companyPVN441);
        }

        // GET: CompamyPVN441s/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPVN441 = await _context.CompanyPVN441
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companyPVN441 == null)
            {
                return NotFound();
            }

            return View(companyPVN441);
        }

        // POST: CompamyPVN441s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var companyPVN441 = await _context.CompanyPVN441.FindAsync(id);
            _context.CompanyPVN441.Remove(companyPVN441);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyPVN441Exists(string id)
        {
            return _context.CompanyPVN441.Any(e => e.CompanyId == id);
        }
    }
}
