using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioCab.DataAccess.Data;
using RadioCab.Models;

public class FeedbackController : Controller
{
    private readonly ApplicationDbContext _context;

    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitFeedback(Feedback model)
    {
        if (ModelState.IsValid)
        {
            _context.Feedbacks.Add(model);
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
