using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly CrudContext _crudContext;

        public UserController(CrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = await _crudContext.Users.ToListAsync();
            
            return View(users);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _crudContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            var fromDb = await _crudContext.Departments.ToListAsync();
            var departments = new SelectList(fromDb, "ID", "Name");
            ViewData["Departments"] = departments;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                
                _crudContext.Add(user);
                await _crudContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _crudContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

           
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (user != null)
            {
               
                _crudContext.Update(user);
                await _crudContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _crudContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _crudContext.Users.FindAsync(id);
            _crudContext.Users.Remove(course);
            await _crudContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
