using Microsoft.AspNetCore.Mvc;
using Task_Day_2_ASP.Models.ClassBL;
using Task_Day_2_ASP.Models.Entities;

namespace Task_Day_2_ASP.Controllers
{
    public class StudentController1 : Controller
    {
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

    }
}
