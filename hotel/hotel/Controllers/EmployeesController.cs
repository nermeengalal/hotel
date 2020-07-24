using hotel.Models;
using hotel.Models.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    
    public class EmployeesController : Controller
    {
        HotelEntities context = new HotelEntities();
        // GET: Employees
        public ActionResult Index()
        {
            var model = context.Employees.ToList();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = context.Employees.Where(x=>x.id==id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }
            var empl = context.Employees.Where(x => x.id == emp.id).FirstOrDefault();
            empl.name = emp.name;
            empl.ssn = emp.ssn;
            empl.phone = emp.phone;
            empl.address = emp.address;
            empl.period_of_work = emp.period_of_work;
            empl.type_of_work = emp.type_of_work;
            empl.salary = emp.salary;
            empl.start_of_work = emp.start_of_work;
            empl.end_of_work = emp.end_of_work;
            context.SaveChanges();
            TempData["SM"] = "لقد قمت بتعديل بيانات موظف";
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }
            if(context.Employees.Any(x=>x.ssn==emp.ssn))
            {
                ModelState.AddModelError("", "ان رقم البطاقه موجود سابقا");
                return View(emp);
            }
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var emp = context.Employees.Where(x => x.id == id).FirstOrDefault();
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult allattendanceandleave()
        {
            List <attendandleaveviewmodel> empmodel = new List<attendandleaveviewmodel>();
            var model = context.AttendanceAndLeaves.ToList();
             empmodel = (from a in context.AttendanceAndLeaves
                       join e in context.Employees
                       on a.emp_id equals e.id
                       where a.emp_id == e.id
                       select new attendandleaveviewmodel
                       {
                           Empname = e.name,
                           id=a.id,
                           com_in=a.com_in,
                           leave_in=a.leave_in,
                           discount=a.discount

                       }).ToList();
            
            return View(empmodel);
        }

        public ActionResult DeleteAttendance(int id)
        {
            var emp = context.AttendanceAndLeaves.Where(x => x.id == id).FirstOrDefault();
            context.AttendanceAndLeaves.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("allattendanceandleave");
        }

        public ActionResult EditAttendance(int id)
        {
            attendandleaveviewmodel empmodel = new attendandleaveviewmodel();
            empmodel = (from a in context.AttendanceAndLeaves
                        join e in context.Employees
                        on a.emp_id equals e.id
                        where a.emp_id == e.id
                        select new attendandleaveviewmodel
                        {
                            Empname = e.name,
                            id = a.id,
                            com_in = a.com_in,
                            leave_in = a.leave_in,
                            discount = a.discount

                        }).Where(x=>x.id==id).FirstOrDefault();
             
            return View(empmodel);
        }

        [HttpPost]
        public ActionResult EditAttendance(attendandleaveviewmodel modl)
        {

            var con = context.AttendanceAndLeaves.Where(x => x.id == modl.id).FirstOrDefault();
            con.com_in = modl.com_in;
            con.discount = con.discount;
            con.leave_in = modl.leave_in;
            context.SaveChanges();


            return RedirectToAction("allattendanceandleave");
        }

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var emp = context.Employees.ToList();
            foreach (var item in emp)
            {
                list.Add(new SelectListItem { Value = item.id.ToString(), Text = item.name });
            }
            return list;
        }
        public ActionResult addattendance()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult addattendance(AttendanceAndLeave att)
        {
            context.AttendanceAndLeaves.Add(att);
            context.SaveChanges();
            return RedirectToAction("allattendanceandleave");
        }

        [HttpPost]
        public ActionResult SearchAct(string CustomerName)
        {

            List<attendandleaveviewmodel> empmodel = new List<attendandleaveviewmodel>();
            empmodel = (from a in context.AttendanceAndLeaves
                        join e in context.Employees
                        on a.emp_id equals e.id
                        where a.emp_id == e.id
                        select new attendandleaveviewmodel
                        {
                            Empname = e.name,
                            id = a.id,
                            com_in = a.com_in,
                            leave_in = a.leave_in,
                            discount = a.discount

                        }).Where(x => x.Empname == CustomerName).ToList();

            return View("allattendanceandleave", empmodel);
        }


        [HttpPost]
        public ActionResult Searchemp(string Employees)
        {

            var emp = context.Employees.Where(x => x.name == Employees).ToList();

            return View("Index", emp);
        }

       
    }
}