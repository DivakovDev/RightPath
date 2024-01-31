using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin)]
    public class CitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cities
        public IActionResult Index()
        {
            List<City> objCityList = _unitOfWork.City.GetAll().ToList();
            return View(objCityList);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            if (city.Name == city.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.City.Add(city);
                _unitOfWork.Save();
                TempData["success"] = "Градът е създаден успешно!";
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

            City? city = _unitOfWork.City.Get(u => u.Id == id);

            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City city)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.City.Update(city);
                _unitOfWork.Save();
                TempData["success"] = "Детайлите по градът са променени успешно!";
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

            City? cityFromDb = _unitOfWork.City
                .Get(u => u.Id == id);
            if (cityFromDb == null)
            {
                return NotFound();
            }

            return View(cityFromDb);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            City? obj = _unitOfWork.City.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.City.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Градът е изтрит успешно!";
            return RedirectToAction("Index");
        }
    }
}
