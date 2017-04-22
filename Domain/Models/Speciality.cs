using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    public class Speciality
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Speciality()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}