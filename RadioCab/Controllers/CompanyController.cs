using Microsoft.AspNetCore.Mvc;
using RadioCab.Data;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CompanyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        
    }
}
