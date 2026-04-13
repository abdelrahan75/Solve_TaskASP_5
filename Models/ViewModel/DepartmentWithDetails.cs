using Task_Day_2_ASP.Models.Entities;

namespace Task_Day_2_ASP.Models.ViewModel
{
    public class DepartmentWithDetails
    {
        public string? Name { get; set; }

        public string? MrgName { get; set; }

        public int Id { get; set; }

        public List<Student>? Students { get; set; }

        public int Size { get; set; }
    }
}
