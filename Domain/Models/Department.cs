using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Domain.Models
{
    public class Department
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Department()
        {
            Id = Guid.NewGuid().ToString();
            Groups = new List<Group>();
        }
        public string FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}