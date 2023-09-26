using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class RoomRepository :IRoomRepository
    {
        private readonly MyDbContext _mydbcontext; //object
        public RoomRepository(MyDbContext myDbContext)
        {
            _mydbcontext = myDbContext;
        }
        public void Create(Room room)
        {
            _mydbcontext.RoomsTable.Add(room);
            _mydbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Room room = (from roomobj in _mydbcontext.RoomsTable
                               where roomobj.RoomId == Id
                               select roomobj).FirstOrDefault();
            _mydbcontext.RoomsTable.Remove(room);
            _mydbcontext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = (from roomobj in _mydbcontext.RoomsTable
                                      select roomobj).ToList();
            return rooms;

        }
    }
}
