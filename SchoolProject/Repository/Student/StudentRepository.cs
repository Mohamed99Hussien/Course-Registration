using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        
        private readonly MyDbContext _myDbConnection; //object 
        public StudentRepository(MyDbContext myDbContext)
        {

            _myDbConnection = myDbContext; 
        }
        public List<Students> GetAllStudents()
        {
            try
            {
                List<Students> students = (from stdsobj in _myDbConnection.StudentsTable
                                           select stdsobj).ToList();
                return students;
            }
            catch (Exception ex)
            {
                String error = ex.Message;

                return null;
            
            }

        }


        public void Create(Students students)
        {
            /*
            Students students1 = new Students();
            students1.IsActive = false;
            students1.StudentName = "test";
            _myDbConnection.StudentsTable.Add(students1);
            _myDbConnection.SaveChanges();
            */

            
            _myDbConnection.StudentsTable.Add(students);
            _myDbConnection.SaveChanges();
        
        }

        public void Delete(int Id)
        {
            /*  
           string StudentName = (from stdsobj in _myDbConnection.StudentsTable
                                 select stdsobj.StudentName).FirstOrDefault();

           */
            Students students = students = (from stdsobj in _myDbConnection.StudentsTable
                                            where stdsobj.StudentId == Id
                                            select stdsobj).FirstOrDefault();
         
            _myDbConnection.StudentsTable.Remove(students);
            _myDbConnection.SaveChanges();

        }

        
        public void Register(int StudentId, int CourseId)
        {
            StudentCourse obj = new StudentCourse();
            obj.CourseId = CourseId;
            obj.StudentId = StudentId;
            _myDbConnection.StudentCourseTable.Add(obj);
            _myDbConnection.SaveChanges();
            /*
            _myDbConnection.StudentCourseTable.Add(new StudentCourse
            {
                CourseId = CourseId,
                StudentId = StudentId
             });
            */
        }
    }
}
