using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Day_2_ASP.ValidationModels.StudentValidation;

namespace Task_Day_2_ASP.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        [UniqueName(ErrorMessage = "This name is already taken.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
        [NotDefaultAge(ErrorMessage = "Age cannot be zero or unset.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        public List<StuCrsRes>? StuCrsResults { get; set; }
    }
}
