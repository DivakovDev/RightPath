using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Controllers
{
    [Area("Admin")]
    public class LecturesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LecturesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cities
        public IActionResult Index()
        {
            List<Lecture> objLectureList = _unitOfWork.Lecture.GetAll().ToList();
            return View(objLectureList);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lecture.Add(lecture);
                _unitOfWork.Save();
                TempData["success"] = "Лектора е създаден успешно!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lecture? lecture = _unitOfWork.Lecture.Get(u => u.Id == id);

            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lecture lecture)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Lecture.Update(lecture);
                _unitOfWork.Save();
                TempData["success"] = "Детайлите по лектора са променени успешно!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Cities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Lecture? lectureFromDb = _unitOfWork.Lecture
                .Get(u => u.Id == id);
            if (lectureFromDb == null)
            {
                return NotFound();
            }

            return View(lectureFromDb);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            Lecture? obj = _unitOfWork.Lecture.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Lecture.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Лекторът е изтрит успешно!";
            return RedirectToAction("Index");
        }
    }

}

