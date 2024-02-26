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
    public class LecturesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LecturesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Webminars
        public IActionResult Index()
        {
            List<Lecture> objLectureList = _unitOfWork.Lecture.GetAll().ToList();
            return View(objLectureList);
        }

        // GET: Webminars/Create
        public IActionResult Upsert(int? id)
        {
            LectureVM lectureVM = new()
            {
                Lecture = new Lecture()
            };

            if (id == null || id == 0)
            {
                //functionality for create
                return View(lectureVM);
            }
            else
            {
                //functionality for edit
                lectureVM.Lecture = _unitOfWork.Lecture.Get(u => u.Id == id);
                return View(lectureVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(LectureVM lectureVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoothPath, @"images\products");

                    if (!string.IsNullOrEmpty(lectureVM.Lecture.ProfileImage))
                    {
                        //delete old image logic
                        var oldImagePath = Path.Combine(wwwRoothPath, lectureVM.Lecture.ProfileImage.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    lectureVM.Lecture.ProfileImage = @"\images\products\" + fileName;
                }

                if (lectureVM.Lecture.Id == 0)
                {
                    _unitOfWork.Lecture.Add(lectureVM.Lecture);
                    TempData["success"] = "Лектора е създаден успешно!";
                }
                else
                {
                    _unitOfWork.Lecture.Update(lectureVM.Lecture);
                    TempData["success"] = "Лектора е редактиран успешно!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();

        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            Lecture? obj = _unitOfWork.Lecture.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Lecture.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Уебминара е изтрит успешно!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int lectureId)
        {
            Lecture lecture = _unitOfWork.Lecture.Get(u => u.Id == lectureId);
            return View(lecture);
        }

        [HttpPost]
        [ActionName("Details")]
        public IActionResult DetailsPOST(int id)
        {
            Lecture lecture = _unitOfWork.Lecture.Get(u => u.Id == id);
            return View(lecture);
        }

    }
}
