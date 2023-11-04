using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public async Task<IActionResult> ViewAd()
        {
            var allAdvertisements = await _db.Advertisments.ToListAsync();
            return View(allAdvertisements);
        }


    }
}
