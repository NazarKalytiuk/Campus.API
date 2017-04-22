using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestModels
{
    public class RegisterTeacherRequestModel : RegisterUserRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
