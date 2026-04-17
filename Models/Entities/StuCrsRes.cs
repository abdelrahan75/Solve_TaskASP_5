using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Day_2_ASP.Models.Entities
{
    public class StuCrsRes
    {

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int Degree { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }

    }
}
