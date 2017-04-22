using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual Group Group { get; set; }
        public virtual StudentBook StudentBook { get; set; }
        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
