using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Faculty
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Faculty()
        {
            Id = Guid.NewGuid().ToString();
            Departments = new List<Department>();
        }
        public ICollection<Department> Departments { get; set; }
    }
}