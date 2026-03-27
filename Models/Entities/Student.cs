using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Day_2_ASP.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        [ForeignKey("Department")]
        public  int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        public List<StuCrsRes>? StuCrsResults { get; set; }
    }
}
