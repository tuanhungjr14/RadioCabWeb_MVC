using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class AdvertismentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertismentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Advertisments
        public async Task<IActionResult> Index()
        {
              return _context.Advertisments != null ? 
                          View(await _context.Advertisments.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Advertisments'  is null.");
        }

        // GET: Advertisments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Advertisments == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // GET: Advertisments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advertisments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdId,CompanyId,AdTilte,CompanyName,Designation,AdAddress,Mobile,Telephone,Fax,Email,AdDescript")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisment);
                await _context.SaveChangesAsync();
                TempData["success"] = "Advertisement created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: Advertisments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Advertisments == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments.FindAsync(id);
            if (advertisment == null)
            {
                return NotFound();
            }
            return View(advertisment);
        }

        // POST: Advertisments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdId,CompanyId,AdTilte,CompanyName,Designation,AdAddress,Mobile,Telephone,Fax,Email,AdDescript")] Advertisment advertisment)
        {
            if (id != advertisment.AdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertismentExists(advertisment.AdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Advertisement edited succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View(advertisment);
        }

        // GET: Advertisments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Advertisments == null)
            {
                return NotFound();
            }

            var advertisment = await _context.Advertisments
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // POST: Advertisments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Advertisments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Advertisments'  is null.");
            }
            var advertisment = await _context.Advertisments.FindAsync(id);
            if (advertisment != null)
            {
                _context.Advertisments.Remove(advertisment);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Advertisement deleted succesfully";
            return RedirectToAction(nameof(Index));
           
        }

        private bool AdvertismentExists(int id)
        {
          return (_context.Advertisments?.Any(e => e.AdId == id)).GetValueOrDefault();
        }
    }
}
