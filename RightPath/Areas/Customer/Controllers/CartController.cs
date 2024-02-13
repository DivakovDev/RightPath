using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RightPath.Models;
using RightPath.Repository.IRepository;
using System.Security.Claims;

namespace RightPath.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.Get(s => s.ApplicationUserId == userId, "Courses,Webminars");

            ViewBag.Courses = shoppingCart.Courses
                .Select(c => _unitOfWork.Course.Get(course => course.Id == c.Id, "Lecture")).ToList();
            ViewBag.Webminars = shoppingCart.Webminars
                .Select(w => _unitOfWork.Webminar.Get(webminar => webminar.Id == w.Id, "City,Lecture")).ToList();

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult RemoveFromCart(int itemId, string itemType)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCart shoppingCart = _unitOfWork.ShoppingCart.Get(s => s.ApplicationUserId == userId, "Courses,Webminars");

            if (itemType == "Course")
            {
                var courseToRemove = shoppingCart.Courses.FirstOrDefault(c => c.Id == itemId);
                if (courseToRemove != null)
                {
                    shoppingCart.Courses.Remove(courseToRemove);
                    _unitOfWork.Course.Remove(courseToRemove); // Remove from Course table
                }
            }
            else if (itemType == "Webminar")
            {
                var webminarToRemove = shoppingCart.Webminars.FirstOrDefault(w => w.Id == itemId);
                if (webminarToRemove != null)
                {
                    shoppingCart.Webminars.Remove(webminarToRemove);
                    _unitOfWork.Webminar.Remove(webminarToRemove); // Remove from Webminar table
                }
            }

            _unitOfWork.Save(); // Save changes to the database

            return RedirectToAction("Index");
        }

    }
}
