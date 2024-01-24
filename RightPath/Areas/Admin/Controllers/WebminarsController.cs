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
using RightPath.Models.ViewModel;
using RightPath.Repository.IRepository;

namespace RightPath.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebminarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebminarsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Webminars
        public IActionResult Index()
        {
            List<Webminar> objCityList = _unitOfWork.Webminar.GetAll().ToList();
            return View(objCityList);
        }

        // GET: Webminars/Create
        public IActionResult Upsert(int? id)
        {
            WebminarVM webminarVM = new()
            {
                CityList = _unitOfWork.City.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                LectureList = _unitOfWork.Lecture.GetAll().Select(y => new SelectListItem
                {
                    Text = y.Name,
                    Value = y.Id.ToString()
                }),
                Webminar = new Webminar()
            };

            if(id == null || id == 0)
            {
                //functionality for create
                return View(webminarVM);
            }
            else
            {
                //functionality for edit
                webminarVM.Webminar = _unitOfWork.Webminar.Get(u=> u.Id == id);
                return View(webminarVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(WebminarVM webminarVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoothPath, @"images\products");

                    if (!string.IsNullOrEmpty(webminarVM.Webminar.Logo))
                    {
                        //delete old image logic
                        var oldImagePath = Path.Combine(wwwRoothPath, webminarVM.Webminar.Logo.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    webminarVM.Webminar.Logo = @"\images\products\" + fileName;
                }

                if(webminarVM.Webminar.Id == 0)
                {
                    _unitOfWork.Webminar.Add(webminarVM.Webminar);
                    TempData["success"] = "Уебминара е създаден успешно!";
                }
                else
                {
                    _unitOfWork.Webminar.Update(webminarVM.Webminar);
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
