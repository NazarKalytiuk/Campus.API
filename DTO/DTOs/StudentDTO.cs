using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class StudentDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string GroupId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string StudentBookId { get; set; }
        public string StudentBookNumber { get; set; }
    }
}
