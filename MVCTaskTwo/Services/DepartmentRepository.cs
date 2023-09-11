using MVCTaskTwo.Models;
using MVCTaskTwo.Services.IServices;

namespace MVCTaskTwo.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AppDBContext context;
        public DepartmentRepository(AppDBContext _context)
        {
                context= _context;
        }

        public Department GetById(int id)
        {
            return
            context.Departments.FirstOrDefault(x => x.ID == id);
        }
        public List<Department> GetAll()
        {
            List<Department> departments = context.Departments.ToList();

            return departments;
        }

        public void Create(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();

        }
        public void Update(int id, Department department)
        {
            var oldDept = context.Departments.FirstOrDefault(x => x.ID == id);
            oldDept.Name = department.Name;
            oldDept.Manger = department.Manger;
            context.SaveChanges();

        }
        public void Delete(int id)
        {

            var dept = context.Departments.FirstOrDefault(x => x.ID == id);
            context.Departments.Remove(dept);
            context.SaveChanges();

        }
    }
}
