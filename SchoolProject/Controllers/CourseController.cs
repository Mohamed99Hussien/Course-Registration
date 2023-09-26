using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository ,ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);

            }
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index",courses);
        }

        public ActionResult Delete(int Id)
        {
            if (Id > 0)
            {

                _courseRepository.Delete(Id);

            }

            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);

        }
    }
}
