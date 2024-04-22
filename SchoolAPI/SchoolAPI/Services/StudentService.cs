using AutoMapper;
using SchoolAPI.Dto;
using SchoolAPI.Interfaces.Repository;
using SchoolAPI.Interfaces.Services;
using SchoolAPI.Models;

namespace SchoolAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            await _studentRepository.Delete(id);
            return true;
        }

        public async Task<List<StudentDto>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetById(int id)
        {
            var student = await _studentRepository.GetById(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<bool> Create(StudentDto student)
        {
            if (student != null)
            {
                await _studentRepository.Create(student);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(StudentDto student)
        {
            var currentStudent = GetById(student.Id);

            if (currentStudent != null)
            {
                await _studentRepository.Update(student);
                return true;
            }
            return false;
        }
    }
}
