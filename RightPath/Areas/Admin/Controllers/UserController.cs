using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RightPath.Models.ViewModel;
using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace RightPath.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: UserList
        public IActionResult Index()
        {

            return View(_unitOfWork.ApplicationUser.GetAll());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll().ToList();
            return Json(new {data = applicationUsers});
        }
    }
}
