using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
       
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository) 
        {


            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [HttpGet]
        public ViewResult Create() 
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher) 
        { if (teacher != null) 
            {
                _teacherRepository.Create(teacher);

            }

            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index",teachers);
        }

        public ActionResult Delete(int Id)
        {
            if (Id > 0) 
            {

                _teacherRepository.Delete(Id);

            }

            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index",teachers);

        }
    }
}
