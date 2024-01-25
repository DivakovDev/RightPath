using Microsoft.AspNetCore.Mvc;
using RightPath.Models;
using RightPath.Repository.IRepository;
using System.Diagnostics;

namespace RightPath.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Webminar> webminarList = _unitOfWork.Webminar.GetAll(includeProperties: "City,Lecture");
            return View(webminarList);
        }

        public IActionResult Details(int webminarId)
        {
            Webminar webminar = _unitOfWork.Webminar.Get(u => u.Id == webminarId, includeProperties: "City,Lecture");
            return View(webminar);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Lectures()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
