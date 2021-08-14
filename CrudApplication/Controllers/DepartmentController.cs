using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CrudContext _crudContext;

        public DepartmentController(CrudContext crudContext)
        {
            _crudContext = crudContext;
        }

        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            var Departments = await _crudContext.Departments.ToListAsync();
            return View(Departments);
        }

        // GET: DepartmentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _crudContext.Departments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            var users = await _crudContext.Users.Where(x => x.DepartmentID == id).ToListAsync();
            ViewData["Users"] = users;

            return View(course);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department Department)
        {
            if (ModelState.IsValid)
            {
                
                _crudContext.Add(Department);
                await _crudContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(Department);
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var Department = await _crudContext.Departments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Department == null)
            {
                return NotFound();
            }

           
            return View(Department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment(int id, Department Department)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (Department != null)
            {
               
                _crudContext.Update(Department);
                await _crudContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(Department);
        }

        // GET: DepartmentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var course = await _crudContext.Departments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _crudContext.Departments.FindAsync(id);
            _crudContext.Departments.Remove(course);
            await _crudContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
