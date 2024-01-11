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
using RightPath.Models.NewModelView;

namespace RightPath.Controllers
{
    public class WebminarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebminarsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }



        // GET: Webminars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Webminars.ToListAsync());
        }

        // GET: Webminars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webminar = await _context.Webminars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webminar == null)
            {
                return NotFound();
            }

            return View(webminar);
        }

        // GET: Webminars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Webminars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WebminarImage webminar)
        {
            string uniqueFileName = UploadeFile(webminar);
            if (ModelState.IsValid)
            {
                Webminar webminar1 = new Webminar()
                {
                    Title = webminar.Title,
                    WebminarDescription = webminar.WebminarDescription, 
                    StartDate = webminar.StartDate,
                    EndDate = webminar.EndDate,
                    CityId = webminar.CityId,
                    WebminarLogo = uniqueFileName,
                    Lecture1 = webminar.Lecture1,
                    Lecture2 = webminar.Lecture2

                };

                _context.Add(webminar1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webminar);
        }

        private string UploadeFile(WebminarImage webminar)

        {

            string uniqueFileName = null;

            if (webminar.WebminarLogo!= null)
            {

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + webminar.WebminarLogo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Console.WriteLine(filePath);



                using (var fileStream = new FileStream(filePath, FileMode.Create))

                {

                    webminar.WebminarLogo.CopyTo(fileStream);

                }

            }

            return uniqueFileName;

        }

        // GET: Webminars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webminar = await _context.Webminars.FindAsync(id);
            if (webminar == null)
            {
                return NotFound();
            }
            return View(webminar);
        }

        // POST: Webminars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,WebminarDescription,StartDate,EndDate,WebminarLocation,WebminarLogo,Lecture1,Lecture2")] Webminar webminar)
        {
            if (id != webminar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(webminar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebminarExists(webminar.Id))
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
            return View(webminar);
        }

        // GET: Webminars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webminar = await _context.Webminars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webminar == null)
            {
                return NotFound();
            }

            return View(webminar);
        }

        // POST: Webminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webminar = await _context.Webminars.FindAsync(id);
            if (webminar != null)
            {
                _context.Webminars.Remove(webminar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebminarExists(int id)
        {
            return _context.Webminars.Any(e => e.Id == id);
        }
    }
}
