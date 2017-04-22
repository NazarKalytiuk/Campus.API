using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DTO.DTOs;
using Services.Contracts;

namespace Api.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var students = await _studentService.GetStudentsAsync();
            if (students == null)
                return NotFound();
            return Ok(students);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get(string id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        [Route("")]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IHttpActionResult> Post(StudentDTO student)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        [HttpPut]
        [Route("")]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IHttpActionResult> Put(StudentDTO student)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("")]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IHttpActionResult> Delete(string id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("{id}/Group")]
        public async Task<IHttpActionResult> GetGroup(string id)
        {
            var student = await _studentService.GetStudentAsync(id);
            var group = await _groupService.GetAsync(student.GroupId);
            if (group == null)
                return NotFound();
            return Ok(group);
        }

        [HttpGet]
        [Route("{id}/StudentBook")]
        public async Task<IHttpActionResult> GetStudentBook(string id)
        {
            var student = await _studentService.GetStudentAsync(id);
            throw new NotImplementedException();
        }
    }
}