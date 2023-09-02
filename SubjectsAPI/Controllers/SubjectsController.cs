using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectsAPI.Data;

namespace SubjectsAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly DataContext _context;
        public SubjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Subject>>> GetAll()
        {
            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Subject>>>CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subject>>>UpdateSubject(Subject subject)
        {
            var s=await _context.Subjects.FindAsync(subject.SubjectID);
            if (s == null)
            {
                return BadRequest("Subject not found");
            }

            s.SubjectName = subject.SubjectName;
            s.SubjectType = subject.SubjectType;
            s.Semester = subject.Semester;
            s.ProfessorName=subject.ProfessorName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subject>>>DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if(subject == null)
            {
                return BadRequest("Subject not found");
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Subject>>> GetSingle(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return BadRequest("Subject not found");
            }

            return Ok( subject);
        }

    }
}
