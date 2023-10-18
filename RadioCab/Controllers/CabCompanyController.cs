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
    public class CabCompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CabCompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CabCompany
        public async Task<IActionResult> Index()
        {
              return _context.CabCompanies != null ? 
                          View(await _context.CabCompanies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CabCompanies'  is null.");
        }

        // GET: CabCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CabCompanies == null)
            {
                return NotFound();
            }

            var cabCompany = await _context.CabCompanies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (cabCompany == null)
            {
                return NotFound();
            }

            return View(cabCompany);
        }

        // GET: CabCompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CabCompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,ContactPerson,DesignNation,CabAddress,Mobile,Telephone,FaxNumber,Email,MembershipType")] CabCompany cabCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cabCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cabCompany);
        }

        // GET: CabCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CabCompanies == null)
            {
                return NotFound();
            }

            var cabCompany = await _context.CabCompanies.FindAsync(id);
            if (cabCompany == null)
            {
                return NotFound();
            }
            return View(cabCompany);
        }

        // POST: CabCompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,ContactPerson,DesignNation,CabAddress,Mobile,Telephone,FaxNumber,Email,MembershipType")] CabCompany cabCompany)
        {
            if (id != cabCompany.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabCompanyExists(cabCompany.CompanyId))
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
            return View(cabCompany);
        }

        // GET: CabCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CabCompanies == null)
            {
                return NotFound();
            }

            var cabCompany = await _context.CabCompanies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (cabCompany == null)
            {
                return NotFound();
            }

            return View(cabCompany);
        }

        // POST: CabCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CabCompanies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CabCompanies'  is null.");
                
            }
            var cabCompany = await _context.CabCompanies.FindAsync(id);
            if (cabCompany != null)
            {
                _context.CabCompanies.Remove(cabCompany);
                
            }
            TempData["success"] = "Category created succesfully";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabCompanyExists(int id)
        {
          return (_context.CabCompanies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
