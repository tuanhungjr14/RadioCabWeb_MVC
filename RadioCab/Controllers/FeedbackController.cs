using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
