using hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    
    public class LeavController : Controller
    {
        // GET: Leav
        HotelEntities context = new HotelEntities();
        public List<SelectListItem> Getemp()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var emp = context.Employees.ToList();
            foreach (var item in emp)
            {
                list.Add(new SelectListItem { Value = item.id.ToString(), Text = item.name });
            }
            return list;
        }
        public ActionResult Index(string id)
        {
            ViewBag.CompanyId = new SelectList(context.Employees, "id", " name",id);
            if(id==null)
            {
                List<AttendanceAndLeave> model = new List<AttendanceAndLeave>();
                return View(model);
            }
            else
            {

            }
            var sup = context.AttendanceAndLeaves.Where(x => x.emp_id.ToString() == id).ToList();

            return View( sup);
        }

    }
}