using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Day_2_ASP.Models.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }          
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        
        
        public Course? Course { get; set; }
        public Department? Department { get; set; }
    }
}
