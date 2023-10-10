using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
