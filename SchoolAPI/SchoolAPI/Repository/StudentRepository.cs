using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Dto;
using SchoolAPI.Interfaces.Repository;
using SchoolAPI.Models;

namespace SchoolAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public IMapper _mapper { get; }

        public StudentRepository(SchoolDbContext schoolDbContext, IMapper mapper)
        {
            _context = schoolDbContext;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var student = _context.Students.Where(x => x.Id == id).FirstOrDefault();

            if (student != null)
            {
                _context.Students.Remove(student);
                return await SaveChanges();
            }
            return false;
        }
        public Task<List<Student>> GetAll()
        {
            return _context.Students.Include(s=>s.IdGradeNavigation).ToListAsync();
        }
        public async Task<Student> GetById(int id)
        {
            return _context.Students.AsNoTracking()
                                    .Include(s=>s.IdGradeNavigation)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefault();
        }
        public async Task<bool> Create(StudentDto student)
        {
            var studentToSave = _mapper.Map<Student>(student);
            _context.Students.Add(studentToSave);
            return await SaveChanges();
        }
        public async Task<bool> Update(StudentDto student)
        {
            var studentToUpdate = MapToUpdate(student);
            _context.Students.Update(studentToUpdate);
            return await SaveChanges();
        }
        public async Task<bool> SaveChanges()
        {
            var result = await _context.SaveChangesAsync();

            return result == 1 ? true : false;
        }
        private Student MapToUpdate(StudentDto student)
        {
            return new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Document = student.Document,
                Adress = student.Adress,
                Phone = student.Phone,
                IdGrade = student.GradeId
            };
        }
    }
}
