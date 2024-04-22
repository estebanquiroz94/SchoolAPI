using SchoolAPI.Dto;

namespace SchoolAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task<bool> Update(StudentDto student);
        Task<bool> Delete(int id);
    }
}
