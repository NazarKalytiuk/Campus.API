using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class GroupDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DepartmentId { get; set; }
        public string MonitorId { get; set; }
        public string CuratorId { get; set; }
        public string SpecialityId { get; set; }
    }
}
