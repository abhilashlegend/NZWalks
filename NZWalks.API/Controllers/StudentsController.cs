using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult getStudents()
        {
            string[] students = new string[] { "Abhilash", "Abhishek", "Anup" };
            return Ok(students);
        }
    }
}
