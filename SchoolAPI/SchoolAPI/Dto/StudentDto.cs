using SchoolAPI.Models;

namespace SchoolAPI.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
    }
}
