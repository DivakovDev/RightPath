using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Upsert(int? id)
        {
            CitiesVM citiesVM = new()
            {
                City = new City()
            };

            if (id == null || id == 0)
            {
                //functionality for create
                return View(citiesVM);
            }
            else
            {
                //functionality for edit
                citiesVM.City = _unitOfWork.City.Get(u => u.Id == id);
                return View(citiesVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CitiesVM citiesVM)
        {
            if (ModelState.IsValid)
            {
                if (citiesVM.City.Id == 0)
                {
                    _unitOfWork.City.Add(citiesVM.City);
                    TempData["success"] = "Града е добавен успешно!";
                }
                else
                {
                    _unitOfWork.City.Update(citiesVM.City);
                    TempData["success"] = "Града е редактиран успешно!";
                }
                _unitOfWork.Save();
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
