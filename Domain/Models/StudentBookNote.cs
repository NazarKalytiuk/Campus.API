using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentBookNote
    {
        [Key]
        public string Id { get; set; }
        public string StudentBookId { get; set; } // int?
        //public StudentBook StudentBook { get; set; }
        // TODO private setter and get from another prop
        public string TeacherId { get; set; } // int?
        //public TeacherProfile Teacher { get; set; }
        //public DateTime DateTime { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string MarkInACTS { get; set; } // A B C 
        public string Mark { get; set; } // 90 80 need this to calc another
        public string MarkInWord { get; set; } // добре, зарах, відмінно
        public string SubjectId { get; set; }
        //public Subject Subject { get; set; }
        public string Type { get; set; } // zalik ispyt
        public StudentBookNote()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
