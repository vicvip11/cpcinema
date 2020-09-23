using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.WebApplication.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}