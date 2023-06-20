using Microsoft.AspNetCore.Mvc;

namespace HouseEase.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
