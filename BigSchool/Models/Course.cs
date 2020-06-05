using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BigSchool.Models;

namespace BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser Lecture { get; set; }
        public string LectuieiId { get; set; }
        [Required]
        [stringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category category { get; set; }
        public byte categoryId { get; set; }
    }
  
}