using Microsoft.AspNetCore.Mvc;
using RadioCab.Models;

namespace RadioCab.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload(FileUploadModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null && model.File.Length > 0)
                {
                    var fileName = Path.GetFileName(model.File.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(fileStream);
                    }

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

    }
}
