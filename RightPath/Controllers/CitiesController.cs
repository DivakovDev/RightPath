using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RightPath.Data;
using RightPath.Models;
using RightPath.Repository.IRepository;

namespace RightPath.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepo;

        public CitiesController(ICityRepository context)
        {
            _cityRepo = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            List<City> objCityList = _cityRepo.GetAll().ToList();
            return View(objCityList);
        }

        //// GET: Cities/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.Cities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(city);
        //}

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.Add(city);
                _cityRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = _cityRepo.Get(u => u.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(City city)
        {

            if (ModelState.IsValid)
            {
                _cityRepo.Update(city);
                _cityRepo.Save();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City? cityFromDb = _cityRepo
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            City? obj= _cityRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _cityRepo.Remove(obj);
            _cityRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
