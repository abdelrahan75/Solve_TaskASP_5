using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Task_Day_2_ASP.Data.Dbcontext;
using Task_Day_2_ASP.Models.ClassBL;
using Task_Day_2_ASP.Models.Entities;
using Task_Day_2_ASP.Models.ViewModel;

namespace Task_Day_2_ASP.Controllers
{
    public class CourseController : Controller
    {
        CourseBL CourseBL = new CourseBL();
        DepartmentBl DeptBL = new DepartmentBl();

        // GET: Course/Index
        public IActionResult Index()
        {
            return View(CourseBL.GetAll());
        }

        // GET: Course/Add
        public IActionResult Add()
        {
            ViewBag.DeptList = new SelectList(DeptBL.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Course/SaveAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DeptList = new SelectList(DeptBL.GetAll(), "Id", "Name");
                return View("Add", model);
            }

            var course = new Course
            {
                Name = model.Name,
                Degree = model.Degree,
                MinDegree = model.MinDegree,
                DepartmentId = model.DepartmentId
            };

            CourseBL.Add(course);
            return RedirectToAction("Index");
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int id)
        {
            var course = CourseBL.GetById(id);
            if (course == null) return NotFound();

            var model = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                DepartmentId = course.DepartmentId
            };

            ViewBag.DeptList = new SelectList(DeptBL.GetAll(), "Id", "Name", course.DepartmentId);
            return View(model);
        }

        // POST: Course/SaveEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DeptList = new SelectList(DeptBL.GetAll(), "Id", "Name", model.DepartmentId);
                return View("Edit", model);
            }

            var course = CourseBL.GetById(model.Id);
            if (course == null) return NotFound();

            course.Name = model.Name;
            course.Degree = model.Degree;
            course.MinDegree = model.MinDegree;
            course.DepartmentId = model.DepartmentId;

            CourseBL.UpdateDB(course);
            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = CourseBL.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        // POST: Course/ConfirmDelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var course = CourseBL.GetById(id);
            if (course == null) return NotFound();

            CourseBL.DeleteDB(course);
            return RedirectToAction("Index");
        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            var course = CourseBL.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }
    }
}