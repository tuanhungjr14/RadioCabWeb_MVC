using Microsoft.AspNetCore.Mvc;

public class ContactController : Controller
{
    // GET: /Contact
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Contact
    [HttpPost]
    public IActionResult Submit(ContactController model)
    {
        if (ModelState.IsValid)
        {
 
            return RedirectToAction("ThankYou");
        }

        return View(model);
    }
}
