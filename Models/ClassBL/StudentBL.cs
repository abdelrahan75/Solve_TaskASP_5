using Task_Day_2_ASP.Data.Dbcontext;
using Task_Day_2_ASP.Models.Entities;

namespace Task_Day_2_ASP.Models.ClassBL
{
    public class StudentBL
    {
        LearningDbContext Context = new LearningDbContext();

        public List<Student> GetAll()
        {
            return Context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return Context.Students.FirstOrDefault((D) => D.Id == id ); ;
        }
    }
}
