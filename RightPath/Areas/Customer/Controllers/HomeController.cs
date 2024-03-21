using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index(string contentType = null)
        {
            var viewModel = new HomeViewModel();

            if (contentType == "Webminars")
            {
                viewModel.Webminars = GetWebminars();
                ViewBag.ContentType = "Webminars";
            }
            else if (contentType == "Courses")
            {
                viewModel.Courses = GetCourses();
                ViewBag.ContentType = "Courses";
            }
            else
            {
                viewModel.Webminars = GetWebminars();
                viewModel.Courses = GetCourses();
                ViewBag.ContentType = "All";
            }

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
        [ActionName("WebminarDetails")]
        public IActionResult WebminarDetailsPOST(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            Webminar webminar = _unitOfWork.Webminar.Get(c => c.Id == id);
            ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.Get(y => y.ApplicationUserId == userId, "Webminars");

            if(shoppingCart == null)
            {
                shoppingCart = new ShoppingCart() { ApplicationUserId = userId};
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
            }

            if (!shoppingCart.Webminars.Contains(webminar))
            {
                shoppingCart.Webminars.Add(webminar);
                _unitOfWork.ShoppingCart.Update(shoppingCart);
                _unitOfWork.Save();
            }


            return RedirectToAction(nameof(Index));
        }
        public IActionResult CourseDetails(int courseId)
        {
            Course course = _unitOfWork.Course.Get(y => y.Id == courseId, includeProperties: "Lecture");
            return View(course);
        }
        [HttpPost]
        [Authorize]
        [ActionName("CourseDetails")]
        public IActionResult CourseDetailsPOST(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            Course course = _unitOfWork.Course.Get(c => c.Id == id);
            ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.Get(y => y.ApplicationUserId == userId, "Courses");

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart() { ApplicationUserId = userId };
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
            }

            if (!shoppingCart.Courses.Contains(course))
            {
                shoppingCart.Courses.Add(course);
                _unitOfWork.ShoppingCart.Update(shoppingCart);
                _unitOfWork.Save();
            }

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
