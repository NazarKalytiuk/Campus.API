using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Teacher
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public virtual Department Department { get; set; }
        public Teacher()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
