using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    
    public class RoomController : Controller
    {
        HotelEntities context = new HotelEntities();
        // GET: Room
        public ActionResult Index()
        {
            var rooms = context.Rooms.ToList();
            return View(rooms);
        }

        public ActionResult Deleteroom(string id)
        {
            //string sd = id.ToString();
            var room = context.Rooms.Where(x => x.room_num == id).FirstOrDefault();
            context.Rooms.Remove(room);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editroom(string id)
        {
            var room = context.Rooms.Where(x => x.room_num == id).FirstOrDefault();
            return View(room);
        }
        [HttpPost]
        public ActionResult Editroom(Room room)
        {
            var rom = context.Rooms.Where(x => x.room_num == room.room_num).FirstOrDefault();
            rom.room_num = room.room_num;
            rom.type = room.type;
            rom.price = room.price;
            rom.rate = room.rate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult addroom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addroom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }
            if (context.Rooms.Any(x => x.room_num==room.room_num))
            {
                ModelState.AddModelError("", "هذه الغرفه موجوده من قبل");
                return View(room);
            }
            context.Rooms.Add(room);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Searchroom(string num)
        {

            var sup = context.Rooms.Where(x => x.room_num == num).ToList();

            return View("Index", sup);
        }
    }
}