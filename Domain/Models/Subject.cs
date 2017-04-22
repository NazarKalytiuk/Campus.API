using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Subject
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public Subject()
        {
            Id = Guid.NewGuid().ToString();
            //Teachers = new List<TeacherProfile>();
        }
        //public ICollection<TeacherProfile> Teachers { get; set; }
    }
}