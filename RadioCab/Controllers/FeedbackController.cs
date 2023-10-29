using Microsoft.AspNetCore.Mvc;
using RadioCab.Models;

public class FeedbackController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitFeedback(FeedbackModel model)
    {
        if (ModelState.IsValid)
        {
            // Xử lý dữ liệu phản hồi ở đây (ví dụ: lưu vào cơ sở dữ liệu).
            // Sau khi xử lý xong, bạn có thể chuyển hướng hoặc hiển thị một thông báo cảm ơn.

            return RedirectToAction("ThankYou");
        }

        return View("Index", model);
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}
