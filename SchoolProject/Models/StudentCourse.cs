using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    // registartion entity 
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public Students students { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
