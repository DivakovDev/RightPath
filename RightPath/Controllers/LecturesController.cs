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
//using RightPath.Repository.IRepository;

//namespace RightPath.Controllers
//    {
//        [Area("Admin")]
//        public class LecturesController : Controller
//        {
//            private readonly IUnitOfWork _unitOfWork;

//            public LecturesController(IUnitOfWork unitOfWork)
//            {
//                _unitOfWork = unitOfWork;
//            }

//            // GET: Lectures
//            public IActionResult Index()
//            {
//                List<Lecture> objCityList = _unitOfWork.Lecture.GetAll().ToList();
//                return View(objCityList);
//            }

//            // GET: Lectures/Create
//            public IActionResult Create()
//            {
//                return View();
//            }

//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            public IActionResult Create(Lecture lecture)
//            {
//                if (ModelState.IsValid)
//                {
//                    _unitOfWork.Lecture.Add(lecture);
//                    _unitOfWork.Save();
//                    TempData["success"] = "Уебминара е създаден успешно!";
//                    return RedirectToAction("Index");
//                }
//                return View();

//            }

//            //private string UploadeFile(LectureImage lecture)

//            //{

//            //    string uniqueFileName = null;

//            //    if (lecture.LectureLogo!= null)
//            //    {

//            //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

//            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + lecture.LectureLogo.FileName;

//            //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//            //        Console.WriteLine(filePath);



//            //        using (var fileStream = new FileStream(filePath, FileMode.Create))

//            //        {

//            //            lecture.LectureLogo.CopyTo(fileStream);

//            //        }

//            //    }

//            //    return uniqueFileName;

//            //}

//            // GET: Lectures/Edit/5
//            public IActionResult Edit(int? id)
//            {
//                if (id == null || id == 0)
//                {
//                    return NotFound();
//                }

//                Lecture? lectureFromDb = _unitOfWork.Lecture.Get(u => u.Id == id);
//                if (lectureFromDb == null)
//                {
//                    return NotFound();
//                }
//                return View(lectureFromDb);
//            }

//            // POST: Lectures/Edit/5
//            [HttpPost]
//            public IActionResult Edit(Lecture lecture)
//            {
//                if (ModelState.IsValid)
//                {
//                    _unitOfWork.Lecture.Update(lecture);
//                    _unitOfWork.Save();
//                    TempData["success"] = "Уебминара е обновен успешно!";
//                    return RedirectToAction("Index");
//                }
//                return View(lecture);
//            }

//            // GET: Lectures/Delete/5
//            public IActionResult Delete(int? id)
//            {
//                if (id == null || id == 0)
//                {
//                    return NotFound();
//                }

//                Lecture? lectureFromDb = _unitOfWork.Lecture
//                    .Get(u => u.Id == id);
//                if (lectureFromDb == null)
//                {
//                    return NotFound();
//                }

//                return View(lectureFromDb);
//            }

//            // POST: Lectures/Delete/5
//            [HttpPost, ActionName("Delete")]
//            [ValidateAntiForgeryToken]
//            public IActionResult DeleteConfirmed(int? id)
//            {
//                Lecture? obj = _unitOfWork.Lecture.Get(u => u.Id == id);
//                if (obj == null)
//                {
//                    return NotFound();
//                }
//                _unitOfWork.Lecture.Remove(obj);
//                _unitOfWork.Save();
//                TempData["success"] = "Уебминара е изтрит успешно!";
//                return RedirectToAction("Index");
//            }
//        }
//    }

//    public async Task<IActionResult> Create(LectureImage lecture)
//        {
//            string uniqueFileName = UploadeFile(lecture);
//            if (ModelState.IsValid)
//            {
//                Lecture lector = new Lecture()
//                {
//                    LectureName = lecture.LectureName,
//                    LastName = lecture.LastName,
//                    LectureDescription = lecture.LectureDescription,
//                    ProfileImage = uniqueFileName

//                };

//                _context.Add(lector);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(lecture);
//        }
//        private string UploadeFile(LectureImage lecture)
//        {

//            string uniqueFileName = null;

//            if (lecture.ProfileImage != null)
//            {

//                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

//                uniqueFileName = Guid.NewGuid().ToString() + "_" + lecture.ProfileImage.FileName;

//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

//                Console.WriteLine(filePath);



//                using (var fileStream = new FileStream(filePath, FileMode.Create))

//                {

//                    lecture.ProfileImage.CopyTo(fileStream);

//                }

//            }

//            return uniqueFileName;

//        }

//        // GET: Lectures/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var lecture = await _context.Lectures.FindAsync(id);
//            if (lecture == null)
//            {
//                return NotFound();
//            }
//            return View(lecture);
//        }

//        // POST: Lectures/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,LectureName,LastName,LectureDescription,ProfileImage")] Lecture lecture)
//        {
//            if (id != lecture.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(lecture);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LectureExists(lecture.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(lecture);
//        }


//        // GET: Lectures/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var lecture = await _context.Lectures
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (lecture == null)
//            {
//                return NotFound();
//            }

//            return View(lecture);
//        }

//        // POST: Lectures/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var lecture = await _context.Lectures.FindAsync(id);
//            if (lecture != null)
//            {
//                _context.Lectures.Remove(lecture);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LectureExists(int id)
//        {
//            return _context.Lectures.Any(e => e.Id == id);
//        }
//    }
//}
