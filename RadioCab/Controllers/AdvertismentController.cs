using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class AdvertismentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
