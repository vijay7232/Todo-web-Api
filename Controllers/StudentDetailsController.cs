using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    

    public class StudentDetailsController :ControllerBase
    {
        private readonly StudentContext _context;

        public StudentDetailsController(StudentContext context)
        {
            _context = context;
        }

    //Get: api/studentdetails
        // [HttpGet]

        // public async Task<ActionResult<IEnumerable<StudentDetail>>> GetStudentDetails()
        // {
        //     return  await _context.StudentDetails.AnyAsync();
            
        // }

    // Get: api/studentdetails/5

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDetail>> GetStudentById(long id)
    {
        var student = await _context.StudentDetails.FindAsync(id);

        if(student == null)
        {
            return NotFound();
        }
        return student;    
        
    }

    // POST: api/studentdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDetail>> CreateStudentDetail(StudentDetail studentInfo)
        {

            _context.StudentDetails.Add(studentInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudentInfo", new {id = studentInfo.StudentID}, studentInfo);
        //    var newStudent = new StudentDetail
        //    {
        //        StudentID = studentInfo.StudentID,
        //        Name = studentInfo.Name,
        //        City = studentInfo.City,
        //        Goal = studentInfo.Goal
        //    };
        //    _context.StudentDetails.Add(newStudent);
        //    await _context.SaveChangesAsync();

        //     return newStudent;
        }



    }
}