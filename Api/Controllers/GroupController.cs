using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using DTO.DTOs;
using Services.Contracts;

namespace Api.Controllers
{
    [RoutePrefix("api/group")]
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var groups = await _groupService.GetAsync();
            if (groups == null)
                return NotFound();
            return Ok(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(string id)
        {
            var groups = await _groupService.GetStudentsAsync("");

            return Ok(groups);
        }

        [HttpGet]
        [Route("{id}/students")]
        public async Task<StudentDTO> GetStudentsByGroupId(string id)
        {
            var groups = await _groupService.GetStudentsAsync("");

            return groups.FirstOrDefault();
        }
    }
}