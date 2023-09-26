using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _mydbcontext; //object
        public TeacherRepository(MyDbContext myDbContext ) 
        {
            _mydbcontext = myDbContext;
        }
        public void Create(Teacher teacher)
        {
            _mydbcontext.TeachersTable.Add(teacher);
            _mydbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Teacher teacher = (from teacherobj in _mydbcontext.TeachersTable
                               where teacherobj.TeacherId == Id
                               select teacherobj).FirstOrDefault();
            _mydbcontext.TeachersTable.Remove(teacher);
            _mydbcontext.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = (from teacherobj in _mydbcontext.TeachersTable
                                      select teacherobj).ToList();
            return teachers;
            
        }
    }
}
