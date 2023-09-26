using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHostingEnvironment _environment;
        public StudentsController(IStudentRepository studentRepository , ICourseRepository courseRepository,
            IHostingEnvironment environment )
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _environment = environment;
        }
        // List of Student
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = "Mohamed Husseien";
            ViewData["Message"]= "CS";
            List<Students> sdtlist = _studentRepository.GetAllStudents();
            return View(sdtlist);
        }
        // render creation view
        [HttpGet]
        public ViewResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Students students,IFormfile StudentPhoto) 
        {
            var wwroot = _environment.WebRootPath + "/StudentPictures/";
            Guid guid = Guid.NewGuid();
            String fullpath = System.IO.Path.Combine(wwroot,guid+ StudentPhoto.FileName);
            using (var fileStream = new FileStream(fullpath,FileMode.Create)) {
                StudentPhoto.CopyTo(fileStream);
            }
            students.photoName = guid + StudentPhoto.FileName;
                _studentRepository.Create(students);
            List<Students> sdtlist = _studentRepository.GetAllStudents();
            return View("Index" , sdtlist);
        
        }
        public ViewResult Delete(int Id)
        {
            _studentRepository.Delete(Id);
            List<Students> sdtlist = _studentRepository.GetAllStudents();
            return View("Index" , sdtlist);
        }
        [HttpGet]
        public ActionResult Register()
        {
            StudentCourseVM data = new StudentCourseVM();
            data.courses = _courseRepository.GetAllCourses();
            data.students = _studentRepository.GetAllStudents();
            return View(data);
        }
        [HttpPost]
        public ActionResult Register(int StudentId , int CourseId)
        {
            _studentRepository.Register(StudentId , CourseId);
            return RedirectToAction("Register");
        }
    }

    public interface IFormfile
    {
        string FileName { get; set; }

        void CopyTo(FileStream fileStream);
    }
}
