namespace Task_Day_2_ASP.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public string? MgrName { get; set; }

        public List<Teacher>? Teachers  { get; set; }

        public List<Course>? Courses { get; set; } 

        public List<Student>? Students { get; set; }


    }
}
