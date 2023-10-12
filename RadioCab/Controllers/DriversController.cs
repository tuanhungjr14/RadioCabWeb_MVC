using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
