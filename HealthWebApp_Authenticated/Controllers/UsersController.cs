using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthWebApp_Authenticated.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthWebApp_Authenticated.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Các Action 
        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = db.Users.ToList();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = string.Join(", ", userManager.GetRoles(user.Id))
                };
                userViewModels.Add(userViewModel);
            }
            return View(userViewModels);
        }
        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var allRoles = db.Roles.Select(r => r.Name).ToList();
            var userRoles = userManager.GetRoles(user.Id);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = userRoles
            };

            ViewBag.AllRoles = allRoles;
            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = await userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var userRoles = await userManager.GetRolesAsync(user.Id);
                selectedRoles = selectedRoles ?? new string[] { };

                var result = await userManager.AddToRolesAsync(user.Id, selectedRoles.Except(userRoles).ToArray());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to add roles");
                    return View(model);
                }

                result = await userManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRoles).ToArray());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove roles");
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
