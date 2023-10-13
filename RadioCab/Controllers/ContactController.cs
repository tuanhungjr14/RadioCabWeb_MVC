using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
