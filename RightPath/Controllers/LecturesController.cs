using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RightPath.Data;
using RightPath.Models;
using RightPath.Models.NewModelView;

namespace RightPath.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LecturesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Lectures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lectures.ToListAsync());
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectureImage lecture)
        {
            string uniqueFileName = UploadeFile(lecture);
            if (ModelState.IsValid)
            {
                Lecture lector = new Lecture()
                {
                    LectureName = lecture.LectureName,
                    LastName = lecture.LastName,
                    LectureDescription = lecture.LectureDescription,
                    ProfileImage = uniqueFileName

                };

                _context.Add(lector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }
        private string UploadeFile(LectureImage lecture)
        {

            string uniqueFileName = null;

            if (lecture.ProfileImage != null)
            {

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + lecture.ProfileImage.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Console.WriteLine(filePath);



                using (var fileStream = new FileStream(filePath, FileMode.Create))

                {

                    lecture.ProfileImage.CopyTo(fileStream);

                }

            }

            return uniqueFileName;

        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LectureName,LastName,LectureDescription,ProfileImage")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                try
                {
                    var lectureToUpdate = await _context.Lectures.FindAsync(id);
                    if (lectureToUpdate == null)
                    {
                        return NotFound();
                    }

                    // Update properties
                    lectureToUpdate.LectureName = lecture.LectureName;
                    lectureToUpdate.LastName = lecture.LastName;
                    lectureToUpdate.LectureDescription = lecture.LectureDescription;
                    lectureToUpdate.ProfileImage = lecture.ProfileImage;

                    _context.Update(lectureToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }


        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture != null)
            {
                _context.Lectures.Remove(lecture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
