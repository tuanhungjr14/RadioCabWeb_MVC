using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class RadioCabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
