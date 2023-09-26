using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public String TeacherName { get; set; }
        public bool IsActive { get; set; }
        [Range(22, 70)]
        public int TeacherAge { get; set; }

    }
}
