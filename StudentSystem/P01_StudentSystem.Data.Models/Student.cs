using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string? PhoneNumber  { get; set; }


        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();

        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

    }
}
