using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {

            _roomRepository = roomRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }

        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);

            }
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index",rooms);
        }

        public ActionResult Delete(int Id)
        {
            if (Id > 0)
            {

                _roomRepository.Delete(Id);

            }

            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index",rooms);

        }
    }
}
