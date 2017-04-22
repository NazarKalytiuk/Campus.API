using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Models
{
    public class Group
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Group()
        {
            Id = Guid.NewGuid().ToString();
            Students = new List<Student>();
        }
        public virtual ICollection<Student> Students { get; set; }
        public virtual Department Department { get; set; }
        public virtual Student Monitor { get; set; } // starosta
        public virtual Teacher Curator { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}