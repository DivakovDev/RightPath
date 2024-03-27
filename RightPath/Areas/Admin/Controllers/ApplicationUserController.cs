using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RightPath.Data;
using RightPath.Models;
using RightPath.Repository;
using System.Data;

namespace RightPath.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin)]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UnitOfWork _unitOfWork;

        public ApplicationUserController(ApplicationDbContext  context, UserManager<ApplicationUser> userManager, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _context.ApplicationUsers.ToListAsync();
            var displayUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, StaticDetail.Role_Lecture) || await _userManager.IsInRoleAsync(user, StaticDetail.Role_Customer))
                {
                    displayUsers.Add(user);
                }
            }

            return View(displayUsers);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser model, string newPassword, string confirmPassword)
        {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.FirstName = model.FirstName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.EGN = model.EGN;

                if (!string.IsNullOrEmpty(newPassword))
                {
                    if (newPassword != confirmPassword)
                    {
                        ModelState.AddModelError("PasswordHash", "Паролите не съвпадат.");
                        return View(model);
                    }

                    var passwordHash = _userManager.PasswordHasher.HashPassword(user, newPassword);
                    user.PasswordHash = passwordHash;
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            ApplicationUser user = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _unitOfWork.ApplicationUser.Remove(user);
            _unitOfWork.Save();
            TempData["success"] = "Потребителят е изтрит успешно!";
            return RedirectToAction("Index");
        }
    }
}
