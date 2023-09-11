using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCTaskTwo.Models;
using MVCTaskTwo.Services;
using MVCTaskTwo.Services.IServices;

namespace MVCTaskTwo.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        IInstructorRepository instRepo ;
        IDepartmentRepository deptRepo;
        public InstructorController(IInstructorRepository _instRepo, IDepartmentRepository _deptRepo)
        {
            instRepo = _instRepo;
            deptRepo = _deptRepo; 
        }
       
        public IActionResult Index()
        {
            List<Instructor> i = instRepo.GetAll();
            var DeptName = deptRepo.GetAll();
                ViewBag.DeptName = DeptName;
            
                return View("Index",i);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Add() 
        {  
            var instructor = new Instructor();

            List<Department> DeptName = deptRepo.GetAll();

                ViewBag.DeptName = DeptName;
            
            return View(instructor);
        }

        public IActionResult SaveAdd(Instructor instructor)
        {
            if (ModelState.IsValid == true)
            {
                instRepo.Create(instructor);
                return RedirectToAction("Index");
                    
            }
            List<Department> DeptName = deptRepo.GetAll();
            ViewBag.DeptName = DeptName;
            return View("Add",instructor);
        }

        public IActionResult GetInstructor(int id)
        {
            Instructor? i;
           
            
                i = instRepo.GetById(id);

            
            return View("GetInstructor", i);
        }
        
        public IActionResult Edit(int id) 
        {
            Instructor? i;
           List<Department> dept;
            
            
               i= instRepo.GetById(id);
            dept = deptRepo.GetAll();
                ViewBag.Dept = dept;
                return View(i);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id ,Instructor newInstructor) 
        {
           
           
                Instructor? oldIns = instRepo.GetById(id);
                if( ModelState.IsValid) 
                {
                    instRepo.Update(id, newInstructor);
                    return RedirectToAction("Index");
                }
                return View("Edit",id);
            
        }

        public IActionResult Delete(int id) 
        {
            try
            {
                instRepo.Delete(id);
                return RedirectToAction("Index");
            }catch(Exception ex) 
            {
                ModelState.AddModelError("Delete Exception",ex.InnerException.Message);
                return RedirectToAction("Index");

            }

        }

        public IActionResult NameExist(string Name , int ID)
        {
            Instructor? instructor = instRepo.GetByName(Name);
            if (ID == 0 ) // ADD
            {
                if (instructor == null)
                    return Json(true);
                else
                    return Json(false);
            }
            else // Edit
            {
                if(instructor == null)
                    return Json(true);
                else if (instructor.ID != ID) 
                    return Json(true);
                else
                {
                    return Json(false);
                }
            }
        }
    }
}
