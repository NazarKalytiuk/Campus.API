//using auth2.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace auth2.Controllers
//{
//    public class TeacherController : ApiController
//    {
//        UnitOfWork unitOfWork;
//        public TeacherController()
//        {
//            unitOfWork = new UnitOfWork();
//        }
//        [HttpGet]
//        public async Task<IHttpActionResult> Get()
//        {
//            var students = await unitOfWork.Teachers.GetAllAsync();

//            return Ok(students);
//        }

//    }
//}

