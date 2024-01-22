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

namespace RightPath.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebminarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WebminarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Webminars
        public IActionResult Index()
        {
            List<Webminar> objCityList = _unitOfWork.Webminar.GetAll().ToList();
            return View(objCityList);
        }

        // GET: Webminars/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CityList = _unitOfWork.City.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewData["CityList"] = CityList;

            IEnumerable <SelectListItem> LectureList = _unitOfWork.Lecture.GetAll().Select(y => new SelectListItem
            {
                Text = y.Name,
                Value = y.Id.ToString()
            });

            ViewData["LectureList"] = LectureList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Webminar webminar)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Webminar.Add(webminar);
                _unitOfWork.Save();
                TempData["success"] = "Уебминара е създаден успешно!";
                return RedirectToAction("Index");
            }
            return View();

        }

        //private string UploadeFile(WebminarImage webminar)

        //{

        //    string uniqueFileName = null;

        //    if (webminar.WebminarLogo!= null)
        //    {

        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + webminar.WebminarLogo.FileName;

        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        Console.WriteLine(filePath);



        //        using (var fileStream = new FileStream(filePath, FileMode.Create))

        //        {

        //            webminar.WebminarLogo.CopyTo(fileStream);

        //        }

        //    }

        //    return uniqueFileName;

        //}

        // GET: Webminars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Webminar? webminarFromDb = _unitOfWork.Webminar.Get(u => u.Id == id);
            if (webminarFromDb == null)
            {
                return NotFound();
            }
            return View(webminarFromDb);
        }

        // POST: Webminars/Edit/5
        [HttpPost]
        public IActionResult Edit(Webminar webminar)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Webminar.Update(webminar);
                _unitOfWork.Save();
                TempData["success"] = "Уебминара е обновен успешно!";
                return RedirectToAction("Index");
            }
            return View(webminar);
        }

        // GET: Webminars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Webminar? webminarFromDb = _unitOfWork.Webminar
                .Get(u => u.Id == id);
            if (webminarFromDb == null)
            {
                return NotFound();
            }

            return View(webminarFromDb);
        }

        // POST: Webminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            Webminar? obj = _unitOfWork.Webminar.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Webminar.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Уебминара е изтрит успешно!";
            return RedirectToAction("Index");
        }
    }
}
