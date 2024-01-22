//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using RightPath.Data;
//using RightPath.Models;

//namespace RightPath.Controllers
//{
//    public class CoursesController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IWebHostEnvironment _webHostEnvironment;


//        public CoursesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        // GET: Courses
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Courses.ToListAsync());
//        }

//        // GET: Courses/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var course = await _context.Courses
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (course == null)
//            {
//                return NotFound();
//            }

//            return View(course);
//        }

//        // GET: Courses/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Courses/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Course course)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(course);
//                _context.SaveChanges();
//                TempData["success"] = "Курса е добавен успешно!";
//                return RedirectToAction("Index");
//            }
//            return View(course);
//        }

//        //private string UploadeFile(CourseImage course)

//        //{

//        //    string uniqueFileName = null;

//        //    if (course.CourseLogo!= null)
//        //    {

//        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

//        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + course.CourseLogo.FileName;

//        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//        //        Console.WriteLine(filePath);



//        //        using (var fileStream = new FileStream(filePath, FileMode.Create))

//        //        {

//        //            course.CourseLogo.CopyTo(fileStream);

//        //        }

//        //    }

//        //    return uniqueFileName;

//        //}

//        // GET: Courses/Edit/5
//        public IActionResult Edit(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }

//            Course? courseFromDb = _unitOfWork.Webminar.Get(u => u.Id == id);
//            if (courseFromDb == null)
//            {
//                return NotFound();
//            }
//            return View(courseFromDb);
//        }

//        // POST: Courses/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Course course)
//        {
//            if (ModelState.IsValid)
//            {
//                _unitOfWork.Webminar.Update(course);
//                _unitOfWork.Save();
//                TempData["success"] = "Курса е обновен успешно!";
//                return RedirectToAction("Index");
//            }
//            return View(course);
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }

//            Course? courseFromDb = _unitOfWork.Course
//                .Get(u => u.Id == id);
//            if (courseFromDb == null)
//            {
//                return NotFound();
//            }

//            return View(courseFromDb);
//        }

//        // POST: Course/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int? id)
//        {
//            Course? obj = _unitOfWork.Course.Get(u => u.Id == id);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            _unitOfWork.Course.Remove(obj);
//            _unitOfWork.Save();
//            TempData["success"] = "Курса е изтрит успешно!";
//            return RedirectToAction("Index");
//        }
//    }
//}
