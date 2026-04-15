using System.ComponentModel.DataAnnotations;

namespace Task_Day_2_ASP.Models.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100.")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "Minimum degree is required.")]
        [Range(0, 100, ErrorMessage = "Minimum degree must be between 0 and 100.")]
        public int MinDegree { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int? DepartmentId { get; set; }
    }
}
