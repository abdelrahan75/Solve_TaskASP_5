using Task_Day_2_ASP.Data.Dbcontext;
using Task_Day_2_ASP.Models.Entities;

namespace Task_Day_2_ASP.Models.ClassBL
{
    public class DepartmentBl
    {
        LearningDbContext Context = new LearningDbContext();

        public List<Department> ShowAll()
        {
            return Context.Departments.ToList();
        }

        public Department ShowByID(int id)
        {
            return Context.Departments.FirstOrDefault((d) => d.Id == id);
        }

        public void UpdateDB(Department updateDpt)
        {
            Context.Departments.Update(updateDpt);
            Context.SaveChanges();
        }

        public void DeleteDB(Department removedpt)
        {
            Context.Departments.Remove(removedpt);
        }
        public void Add(Department Dpt)
        {

            Context.Departments.Add(Dpt);
            Context.SaveChanges();
        }


    }
}
