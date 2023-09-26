using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Students> GetAllStudents();

        public void Create(Students students);
        public void Delete(int Id);
        public void Register(int StudentId, int CourseId);
    }
}
