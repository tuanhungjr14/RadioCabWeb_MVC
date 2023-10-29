using Microsoft.AspNetCore.Mvc;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class AdvertismentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdvertismentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Advertisment> objAdvertismentList = _db.Advertisments.ToList(); ;
            return View(objAdvertismentList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Advertisment obj)
        {
            if(ModelState.IsValid)
            { 
                _db.Advertisments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
