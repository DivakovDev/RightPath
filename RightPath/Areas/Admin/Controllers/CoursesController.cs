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
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoursesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Webminars
        public IActionResult Index()
        {
            List<Course> objLectureList = _unitOfWork.Course.GetAll(includeProperties: "Lecture").ToList();
            return View(objLectureList);
        }

        // GET: Webminars/Create
        public IActionResult Upsert(int? id)
        {
            CourseVM courseVM = new()
            {
                LectureList = _unitOfWork.Lecture.GetAll().Select(y => new SelectListItem
                {
                    Text = y.Name,
                    Value = y.Id.ToString()
                }),
                Course = new Course()
            };

            if (id == null || id == 0)
            {
                //functionality for create
                return View(courseVM);
            }
            else
            {
                //functionality for edit
                courseVM.Course = _unitOfWork.Course.Get(u => u.Id == id);
                return View(courseVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CourseVM courseVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoothPath, @"images\products");

                    if (!string.IsNullOrEmpty(courseVM.Course.Logo))
                    {
                        //delete old image logic
                        var oldImagePath = Path.Combine(wwwRoothPath, courseVM.Course.Logo.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    courseVM.Course.Logo = @"\images\products\" + fileName;
                }

                if (courseVM.Course.Id == 0)
                {
                    _unitOfWork.Course.Add(courseVM.Course);
                    TempData["success"] = "Уебминара е създаден успешно!";
                }
                else
                {
                    _unitOfWork.Course.Update(courseVM.Course);
                    TempData["success"] = "Уебминара е редактиран успешно!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Webminars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Course? courseFromDb = _unitOfWork.Course
                .Get(u => u.Id == id);
            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);
        }

        // POST: Webminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            Course? obj = _unitOfWork.Course.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Уебминара е изтрит успешно!";
            return RedirectToAction("Index");
        }
    }
}
