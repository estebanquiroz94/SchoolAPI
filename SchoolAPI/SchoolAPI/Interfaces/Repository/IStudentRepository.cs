using SchoolAPI.Dto;
using SchoolAPI.Models;

namespace SchoolAPI.Interfaces.Repository
{
    public interface IStudentRepository
    {
        Task<Student> GetById(int id);
        Task<List<Student>> GetAll();
        Task<bool> Create(StudentDto student);
        Task<bool> Update(StudentDto student);
        Task<bool> Delete(int id);
        Task<bool> SaveChanges();
    }
}
