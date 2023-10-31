using Microsoft.AspNetCore.Mvc;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

public class ContactController : Controller
{
    // GET: /Contact
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitContact(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Contact.Add(model);
            _context.SaveChanges();

            return RedirectToAction("ThankYou");
        }

        return View("Index", model);
    }
    public IActionResult ThankYou()
    {
        return View();
    }
}
