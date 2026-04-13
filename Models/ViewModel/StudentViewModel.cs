using System.ComponentModel.DataAnnotations.Schema;
using Task_Day_2_ASP.Models.Entities;

namespace Task_Day_2_ASP.Models.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }    
        public int? DepartmentId { get; set; }
        public List<Department>? departments { get; set; }
    }
}
