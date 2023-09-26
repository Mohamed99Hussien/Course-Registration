using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class CourseRepository :ICourseRepository
    {
        private readonly MyDbContext _mydbcontext; //object
        public CourseRepository(MyDbContext myDbContext)
        {
            _mydbcontext = myDbContext;
        }
        public void Create(Course course)
        {
            _mydbcontext.CoursesTable.Add(course);
            _mydbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Course course = (from courseobj in _mydbcontext.CoursesTable
                               where courseobj.CourseId == Id
                               select courseobj).FirstOrDefault();
            _mydbcontext.CoursesTable.Remove(course);
            _mydbcontext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = (from courseobj in _mydbcontext.CoursesTable
                                select courseobj).ToList();
            return courses;

        }
    }
}
