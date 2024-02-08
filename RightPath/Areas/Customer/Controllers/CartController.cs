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
                .Select(c => _unitOfWork.Course.Get(course =>course.Id == c.Id, "Lecture")).ToList();
            ViewBag.Webminars = shoppingCart.Webminars
                .Select(c => _unitOfWork.Webminar.Get(course => course.Id == c.Id, "City,Lecture")).ToList();

            return View();
        }
    }
}
