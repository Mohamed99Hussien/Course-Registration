using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Students
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public String StudentName { get; set; }
        public bool IsActive { get; set; }
        [Range(5,18)]
        public int StudentAge { get; set; }
        public String photoName { get; set; }


    }
}
