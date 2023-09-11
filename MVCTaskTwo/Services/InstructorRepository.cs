using MVCTaskTwo.Models;
using MVCTaskTwo.Services.IServices;

namespace MVCTaskTwo.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        AppDBContext context;
        public InstructorRepository(AppDBContext _context)
        {
            context = _context;
        }

        public Instructor GetById(int id)
        {
            return
            context.Instructors.FirstOrDefault(x => x.ID == id);
        }

        public Instructor GetByName(string name)
        {
            return context.Instructors.FirstOrDefault(x => x.Name == name);

        }

        public List<Instructor> GetAll()
        {
            List<Instructor> instructors = context.Instructors.ToList();

            return instructors;
        }

        public void Create(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();

        }
        public void Update(int id, Instructor instructor)
        {
            var oldins = context.Instructors.FirstOrDefault(x => x.ID == id);
            oldins.Name = instructor.Name;
            oldins.Dept_ID = instructor.Dept_ID;
            oldins.Address = instructor.Address;
            oldins.Salary = instructor.Salary;

            context.SaveChanges();
            
            
        }
       
        public void Delete(int id)
        {

            var inst = context.Instructors.FirstOrDefault(x => x.ID == id);
            context.Instructors.Remove(inst);
            context.SaveChanges();

        }

    }
}
