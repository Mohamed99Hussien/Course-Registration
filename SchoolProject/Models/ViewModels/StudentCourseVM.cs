using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models.ViewModels
{
    public class StudentCourseVM
    {
       public List<Students> students { get; set; }
       public List<Course> courses { get; set; }
    }
}
