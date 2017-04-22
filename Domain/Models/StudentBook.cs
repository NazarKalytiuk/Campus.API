using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class StudentBook
    {
        [Key]
        public string Id { get; set; }
        public string Number { get; set; }
        //public ICollection<StudentBookNote> Notes { get; set; }
        public StudentBook()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}