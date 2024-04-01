using Microsoft.AspNetCore.Mvc;

namespace RightPath.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ForUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
