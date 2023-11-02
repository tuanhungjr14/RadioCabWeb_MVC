using Microsoft.AspNetCore.Mvc;

namespace RadioCab.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult PaymentMethod()
        {
            return View();
        }

        public IActionResult ProcessPayment(string membershipType, string paymentType)
        {
            // Process payment logic
            // Use PayPal SDK or API to handle payment processing
            // The following code is a placeholder, actual PayPal integration is needed

            // After processing payment, redirect to success page
            return RedirectToAction("PaymentSuccess");
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }
    }
}
