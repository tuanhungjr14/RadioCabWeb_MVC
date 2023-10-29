using Microsoft.AspNetCore.Mvc;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DriversController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Details()
        {
            List<Driver> objDriverList = _db.Drivers.ToList(); ;
            return View(objDriverList);
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
