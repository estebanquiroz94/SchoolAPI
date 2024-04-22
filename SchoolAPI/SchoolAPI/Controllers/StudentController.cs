using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Dto;
using SchoolAPI.Interfaces.Services;

namespace SchoolAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("get")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("create")]
        public async Task<ActionResult<StudentDto>> Create([FromBody] StudentDto student)
        {
            var studentId = await _studentService.Update(student);

            return CreatedAtAction(nameof(Get), new { id = studentId }, student);
        }

        [HttpPost("update")]
        public async Task<ActionResult<StudentDto>> Update([FromBody]StudentDto student)
        {
            var studentId = await _studentService.Update(student);

            return CreatedAtAction(nameof(Get), new { id = studentId }, student);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _studentService.Delete(id);
            return Ok();
        }

    }
}
