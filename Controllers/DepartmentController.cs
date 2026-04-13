using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Day_2_ASP.Models.ClassBL;
using Task_Day_2_ASP.Models.Entities;
using Task_Day_2_ASP.Models.ViewModel;

namespace Task_Day_2_ASP.Controllers
{
    public class DepartmentController: Controller
    {
        DepartmentBl DepartmentBl = new DepartmentBl();
        StudentBL StudentBL = new StudentBL();
        public IActionResult ShowAll()
        {
            List <Department> dep = DepartmentBl.ShowAll();
            return View("ShowAllDep",dep);
        }

        public IActionResult ShowById(int id)
        {
            Department dept = DepartmentBl.ShowByID(id);
            return View("ShowById",dept);
        }

        
        public IActionResult ShowDetails(int id)
        {
            Department Dept = DepartmentBl.ShowByID(id);
            DepartmentWithDetails DeptModel = new DepartmentWithDetails()
            {
                Name = Dept.Name,
                Students = Dept.Students.Where((s) => s.Age <= 25).ToList(),
                Size = Dept.Students.Where((s) => s.Age <= 25).Count()

            };
            return View("Index", Dept);
        }

        public IActionResult Add()
        {
            ViewBag["StdList"] = new SelectList(StudentBL.GetAll(), "Id", "Name");
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Department NewDpt)
        {
            if (ModelState.IsValid)
            {

                DepartmentBl.Add(NewDpt);
                return RedirectToAction(nameof(Index));
            }
            ViewBag["StdList"] = new SelectList(StudentBL.GetAll(), "Id", "Name");
            return View("Add", NewDpt);
        }

        [HttpGet]
        public IActionResult SaveEdit(Department NewDpt, int id)
        {
           
            Department OldDpt = DepartmentBl.ShowByID(id);
          
            if (ModelState.IsValid)
            {
                
               OldDpt.Name = NewDpt.Name;
                OldDpt.Id= NewDpt.Id;
                OldDpt.MgrName = NewDpt.MgrName;
                DepartmentBl.UpdateDB(NewDpt);
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", NewDpt);
        }
    }
}
