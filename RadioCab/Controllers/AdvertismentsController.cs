using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdvertismentsController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _signInManager = signInManager;
            if (_context.Advertisments == null)
            {
                throw new ArgumentNullException(nameof(_context.Advertisments), "Entity set 'ApplicationDbContext.Advertisments' is null.");
            }
        }
        [Authorize(Roles = "Admin, Company")]
        // GET: Advertisments
        public async Task<IActionResult> Index()
        {
            var user = _signInManager.Context.User;

            if (user.IsInRole("Admin"))
            {
                var allAdvertisements = await _context.Advertisments.ToListAsync();
                return View(allAdvertisements);
            }
            else
            {
                string userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Check if the user has a RolePayment entry
                var rolePayment = await _context.RolePayments
                    .Where(rp => rp.RoleId == userId)
                    .FirstOrDefaultAsync();

                if (rolePayment == null || rolePayment.Price == 0)
                {
                    return View("Payment"); // Display the payment page if the Price is null or zero
                }
                else
                {
                    var userAdvertisements = await _context.Advertisments
                        .Where(a => a.CompanyId == userId)
                        .ToListAsync();
                    return View(userAdvertisements); // Show the user's advertisements
                }
            }
        }

        public async Task<IActionResult> ViewAd()
        {
            var allAdvertisements = await _context.Advertisments.ToListAsync();
            return View(allAdvertisements);
        }

        // GET: Advertisments/Details/5
        public async Task<IActionResult >DetailsAd(int? id)
        {
        if (id == null || _context.Advertisments == null)
        {
        return NotFound();
        }

        var advertisment = await _context.Advertisments.FirstOrDefaultAsync(m => m.AdId == id);
        if (advertisment == null)
        {
        return NotFound();
         }

        return View(advertisment);
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
            string userId = _signInManager.Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ViewBag.AllUsers = _context.ApplicationUsers.ToList();
            var newAdvertisment = new Advertisment
            {
                
                CompanyId = userId 
            };

            return View(newAdvertisment);
        }

        // POST: Advertisments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdId,CompanyId,AdTitle,CompanyName,Designation,AdAddress,Mobile,Telephone,Fax,Email,AdDescript,ImageUrl")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisment);
                await _context.SaveChangesAsync();
                TempData["success"] = "Advertisement created successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(advertisment);
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
        public async Task<IActionResult> Edit(int id, [Bind("AdId,CompanyId,AdTitle,CompanyName,Designation,AdAddress,Mobile,Telephone,Fax,Email,AdDescript,ImageUrl")] Advertisment advertisment)
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
        public IActionResult Payment()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Payment(string package)
        {
            ClaimsPrincipal currentUser = _signInManager.Context.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            decimal price = 0;

            if (!string.IsNullOrEmpty(package))
            {
                if (package == "monthly")
                {
                    price = 15;
                }
                else if (package == "quarterly")
                {
                    price = 40;
                }
            }

            var rolePayment = new RolePayment
            {
                RoleId = userId,
                PaymentTypeId = GetPaymentTypeId(package),
                Price = price
            };

            _context.RolePayments.Add(rolePayment);
            await _context.SaveChangesAsync();

            ViewData["Price"] = price;

            return View("PaymentConfirmation");
        }

        private int GetPaymentTypeId(string package)
        {
            if (package == "monthly")
            {
                return 1; 
            }
            else if (package == "quarterly")
            {
                return 2; 
            }

            return 0; 
        }
    }



}

