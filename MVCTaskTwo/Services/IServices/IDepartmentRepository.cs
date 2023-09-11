using MVCTaskTwo.Models;

namespace MVCTaskTwo.Services.IServices
{
    public interface IDepartmentRepository
    {
        void Create(Department department);
        void Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        void Update(int id, Department department);
    }
}