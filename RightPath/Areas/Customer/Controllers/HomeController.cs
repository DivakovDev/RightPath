using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RightPath.Models;
using RightPath.Models.ViewModel;
using RightPath.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

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
            var viewModel = new HomeViewModel
            {
                Webminars = GetWebminars(), 
                Courses = GetCourses()
            };
            return View(viewModel);
        }

        private IEnumerable<Webminar> GetWebminars()
        {
            IEnumerable<Webminar> webminarList = _unitOfWork.Webminar.GetAll(includeProperties: "City,Lecture");
            return (webminarList);
        }

        private IEnumerable<Course> GetCourses()
        {
            IEnumerable<Course> courseList = _unitOfWork.Course.GetAll(includeProperties: "Lecture");
            return (courseList);
        }

        public IActionResult WebminarDetails(int webminarId)
        {
            Webminar webminar = _unitOfWork.Webminar.Get(u => u.Id == webminarId, includeProperties: "City,Lecture");
            return View(webminar);
        }
        [HttpPost]
        [Authorize]
        public IActionResult WebminarDetails(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.Id == shoppingCart.Id);

            if(cartFromDb != null)
            {
                _unitOfWork.ShoppingCart.Update(shoppingCart);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }

            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CourseDetails(int courseId)
        {
            Course course = _unitOfWork.Course.Get(y => y.Id == courseId, includeProperties: "Lecture");
            return View(course);
        }
        [HttpPost]
        [Authorize]
        public IActionResult CourseDetails(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
    u.Id == shoppingCart.Id);

            if (cartFromDb != null)
            {
                _unitOfWork.ShoppingCart.Update(shoppingCart);
            }
            else
            {
                Console.WriteLine("Yoou already add it!");
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
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
