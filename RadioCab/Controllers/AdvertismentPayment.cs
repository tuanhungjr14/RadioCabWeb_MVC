using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class AdvertismentPayment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payment(string package)
        {
            
            if (package == "monthly")
            {
              
                ViewData["Price"] = 15;
            }
            else if (package == "quarterly")
            {
                
                ViewData["Price"] = 40;
            }
            else
            {
                ViewData["Price"] = 0; 
            }

            return View("PaymentConfirmation");
        }
    }
}
