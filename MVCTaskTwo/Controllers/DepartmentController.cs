using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCTaskTwo.Models;
using MVCTaskTwo.Services;
using MVCTaskTwo.Services.IServices;

namespace MVCTaskTwo.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public DepartmentController(IDepartmentRepository _deptRepo)
        {
            deptRepo = _deptRepo;
        }
        // GET: DepartmentController
        public IActionResult Index()
        {
            List<Department> departmentList = deptRepo.GetAll();
            return View(departmentList);
        }

        // GET: DepartmentController/Details/5
        public IActionResult Details(int id)
        {
           Department dept = deptRepo.GetById(id);
            return View(dept);
        }

        // GET: DepartmentController/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                try
                 {
                    deptRepo.Create(dept);
                     return RedirectToAction(nameof(Index));
                 }
              catch (Exception ex)
                 {
                    ModelState.AddModelError("", ex.Message);
                 }

            }
            return View(dept);

        }

        // GET: DepartmentController/Edit/5
        public IActionResult Edit(int id)
        {
           Department dept = deptRepo.GetById(id);
            return View(dept);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department dept)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    deptRepo.Update(id, dept);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                   
                }
            }
            return View(dept);
        }

       
        public IActionResult Delete(int id)
        {
            try
            {
                deptRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Content("Cant Delete this Department");
            }
        }
    }
}
