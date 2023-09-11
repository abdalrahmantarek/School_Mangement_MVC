using MVCTaskTwo.Models;

namespace MVCTaskTwo.Services.IServices
{
    public interface IInstructorRepository
    {
        void Create(Instructor instructor);
        void Delete(int id);
        List<Instructor> GetAll();
        Instructor GetById(int id);
        Instructor GetByName(string name);
        void Update(int id, Instructor instructor);
    }
}