using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Day_2_ASP.Models.ClassBL;
using Task_Day_2_ASP.Models.Entities;
using Task_Day_2_ASP.Models.ViewModel;

namespace Task_Day_2_ASP.Controllers
{
    public class StudentController1 : Controller
    {
        StudentBL StudentBL= new StudentBL();

        DepartmentBl departmentBl = new DepartmentBl();
        //Student/GetAll
        public IActionResult GetAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> studentsAll = studentBL.GetAll();
            return View("View1",studentsAll);
        }

        public IActionResult Detail(int id)
        {
            StudentBL student = new StudentBL();
            Student student1 = student.GetById(3);
            return View("Detail", student1);

        }

        public IActionResult Index()
        {
            return View("Index",StudentBL.GetAll());
        }

        //public IActionResult Edit (int id )
        //{
        //    Student Std = StudentBL.GetById(id);
        //    List<Department> deps = departmentBl.ShowAll();
        //    StudentViewModel SVMD = new StudentViewModel()
        //    {
        //        Id = id,
        //        Age = Std.Age,
        //        Name = Std.Name,
        //        DepartmentId = Std.DepartmentId,
        //        departments = deps
        //    };
        //    return View("Edit",SVMD);
        //}

        public IActionResult SaveEdit(Student NewStudent,int id)
        {
            Student OldStudent  = StudentBL.GetById(id);
            if (ModelState.IsValid)
            {
                //OldStudent.Name = NewStudent.Name;
                //OldStudent.DepartmentId = NewStudent.DepartmentId;
                //OldStudent.Age = NewStudent.Age;
                //OldStudent.Id = NewStudent.Id;

                //StudentBL.UpdateDB(OldStudent);
                StudentBL.UpdateDB(NewStudent);
                return RedirectToAction(nameof(Index));
            }
            return View("Index",NewStudent);
            
        }

        public IActionResult Delete(int id)
        {
            return View("Delete",StudentBL.GetById(id));
        }

        public IActionResult ConfirmDelete (int id)
        {
            Student DelStd = StudentBL.GetById(id);
            if (DelStd != null)
            {
                StudentBL.DeleteDB(DelStd);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Add()
        {
            ViewData["DeptList"] = new SelectList(departmentBl.ShowAll(), "Id", "Name");
            return View("Add"); 
        }

        [HttpPost]
        public IActionResult SaveAdd(Student NewStd)
        {
            if (ModelState.IsValid)
            {
                
               StudentBL.Add(NewStd);
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptList"] = new SelectList(departmentBl.ShowAll(), "Id", "Name");
            return View("Add", NewStd); 
        }

    }
}
