using Microsoft.AspNetCore.Mvc;

namespace Player.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
