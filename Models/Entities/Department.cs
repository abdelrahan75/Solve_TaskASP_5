using System.ComponentModel.DataAnnotations;

namespace Task_Day_2_ASP.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Manager name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Manager name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Manager name can only contain letters and spaces.")]
        public string? MgrName { get; set; }

        public List<Teacher>? Teachers { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Student>? Students { get; set; }
    }
}
